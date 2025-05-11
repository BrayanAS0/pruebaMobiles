using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pruebaMobiles.data;
using pruebaMobiles.Entities;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly AppDbContext _context;

    public WeatherForecastController(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// dsadas
    /// </summary>
    /// <remarks>
    /// sadkjsdklasdkjlkjsda
    /// </remarks>

    [HttpGet("prueba1")]

    public async Task<ActionResult<List<prueba>>> Get()
    {
        var resultados = await _context.prueba.ToListAsync();
        return Ok(resultados);
    }

    // GET: /WeatherForecast/prueba/5
    [HttpGet("prueba/{id}")]
    public async Task<ActionResult<prueba>> GetById(int id)
    {
        var item = await _context.prueba.FindAsync(id);
        if (item == null) return NotFound();
        return Ok(item);
    }

    // POST: /WeatherForecast/prueba
    [HttpPost("prueba")]
    public async Task<ActionResult> Crear(prueba nuevo)
    {
        _context.prueba.Add(nuevo);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = nuevo.id }, nuevo);
    }

    // PUT: /WeatherForecast/prueba/5
    [HttpPut("prueba/{id}")]
    public async Task<ActionResult> Editar(int id, prueba actualizado)
    {
        if (id != actualizado.id)
            return BadRequest("ID no coincide.");

        var existe = await _context.prueba.AnyAsync(x => x.id == id);
        if (!existe) return NotFound();

        _context.Entry(actualizado).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: /WeatherForecast/prueba/5
    [HttpDelete("prueba/{id}")]
    public async Task<ActionResult> Borrar(int id)
    {
        var item = await _context.prueba.FindAsync(id);
        if (item == null) return NotFound();

        _context.prueba.Remove(item);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
