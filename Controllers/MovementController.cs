using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pruebaMobiles.DTOs.MovementDto;

namespace pruebaMobiles.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MovementController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MovementController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetMovements()
        {
            var data = await _context.Movements.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSingleMovement(int id)
        {
            var data = await _context.Movements.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMovement([FromBody] CreateMovementDto movementDto)
        {
            var movement = new Movement
            {
                UserId = movementDto.UserId,
                MaterialId = movementDto.MaterialId,
                Date = movementDto.Date,
                QuantityChanged = movementDto.QuantityChanged,
                Notes = movementDto.Notes
            };

            await _context.Movements.AddAsync(movement);
            await _context.SaveChangesAsync();
            return Ok(true);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditMovement(int id, [FromBody] CreateMovementDto movementDto)
        {
            var movement = await _context.Movements.FindAsync(id);
            if (movement == null) return NotFound();

            movement.UserId = movementDto.UserId;
            movement.MaterialId = movementDto.MaterialId;
            movement.Date = movementDto.Date;
            movement.QuantityChanged = movementDto.QuantityChanged;
            movement.Notes = movementDto.Notes;

            _context.Movements.Update(movement);
            await _context.SaveChangesAsync();
            return Ok(true);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovement(int id)
        {
            var movement = await _context.Movements.FindAsync(id);
            if (movement == null) return NotFound();

            _context.Movements.Remove(movement);
            await _context.SaveChangesAsync();
            return Ok(true);
        }
        [HttpPost]
        public async Task<ActionResult> GenerateDummyMovements()
        {
            var materials = await _context.Materials.ToListAsync();
            if (!materials.Any())
            {
                return BadRequest("No hay materiales en la base de datos.");
            }

            var random = new Random();
            var movements = new List<Movement>();
            var sampleNotes = new[]
            {
        "Entrada por compra",
        "Salida para producción",
        "Ajuste de inventario",
        "Uso en mantenimiento",
        "Devolución de proveedor",
        "Error de carga corregido",
        "Transferencia entre bodegas",
        "Consumo en pruebas",
        "Rotura reportada",
        "Reposición programada"
    };

            for (int i = 0; i < 30; i++)
            {
                var material = materials[random.Next(materials.Count)];
                movements.Add(new Movement
                {
                    UserId = 1,
                    MaterialId = material.Id,
                    Date = DateTime.Now.AddDays(-random.Next(0, 15)),
                    QuantityChanged = random.Next(-10, 15),
                    Notes = sampleNotes[random.Next(sampleNotes.Length)]
                });
            }

            await _context.Movements.AddRangeAsync(movements);
            await _context.SaveChangesAsync();

            return Ok(movements);
        }


    }
}
