using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pruebaMobiles.DTOs.MaterialDto;

namespace pruebaMobiles.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MaterialController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MaterialController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetMaterial()
        {
            var data = await _context.Materials.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSingleMaterial(int id)
        {
            var data = await _context.Materials.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMaterial([FromBody] CreateMaterialDto materialDto)
        {
            var exists = await _context.Materials.AnyAsync(x => x.Name == materialDto.Name);
            if (exists) return Conflict("El material ya existe.");

            var material = new Material
            {
                Name = materialDto.Name,
                Description = materialDto.Description,
                Quantity = materialDto.Quantity,
            };

            await _context.Materials.AddAsync(material);
            await _context.SaveChangesAsync();
            return Ok(true);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditMaterial(int id, [FromBody] CreateMaterialDto materialDto)
        {
            var material = await _context.Materials.FindAsync(id);
            if (material == null) return NotFound();

            material.Name = materialDto.Name;
            material.Description = materialDto.Description;
            material.Quantity = materialDto.Quantity;

            _context.Materials.Update(material);
            await _context.SaveChangesAsync();
            return Ok(true);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMaterial(int id)
        {
            var material = await _context.Materials.FindAsync(id);
            if (material == null) return NotFound();

            _context.Materials.Remove(material);
            await _context.SaveChangesAsync();
            return Ok(true);
        }
        [HttpPost]
        public async Task<ActionResult> GenerateDummyMaterials()
        {
            var materials = new List<Material>
    {
        new Material { Name = "Acero Inoxidable", Description = "Lámina de acero resistente a la corrosión", Quantity = 150 },
        new Material { Name = "Cobre Electrolítico", Description = "Conductor de alta pureza para instalaciones eléctricas", Quantity = 90 },
        new Material { Name = "Plástico ABS", Description = "Material plástico para componentes estructurales", Quantity = 300 },
        new Material { Name = "Aluminio Fundido", Description = "Aleación ligera para piezas mecánicas", Quantity = 110 },
        new Material { Name = "Tornillos M6", Description = "Tornillos de acero galvanizado para montaje", Quantity = 500 },
        new Material { Name = "Cable UTP Cat6", Description = "Cable de red para conexiones LAN", Quantity = 200 },
        new Material { Name = "Resina Epóxica", Description = "Adhesivo industrial de alta resistencia", Quantity = 60 },
        new Material { Name = "Pintura Anticorrosiva", Description = "Revestimiento para proteger superficies metálicas", Quantity = 80 },
        new Material { Name = "Filtros de Aire", Description = "Filtros para equipos industriales o vehículos", Quantity = 40},
        new Material { Name = "Aceite Hidráulico", Description = "Lubricante para sistemas hidráulicos", Quantity = 100 }
    };

            await _context.Materials.AddRangeAsync(materials);
            await _context.SaveChangesAsync();

            return Ok(materials);
        }

    }
}
