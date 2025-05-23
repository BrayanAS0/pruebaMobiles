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
                Date = DateTime.UtcNow,
                QuantityChanged = movementDto.QuantityChanged- movementDto.RealQuantity  ,
            };

            await _context.Movements.AddAsync(movement);
            await _context.SaveChangesAsync();
            return Ok(true);
        }

        //[HttpPut("{id}")]
        //public async Task<ActionResult> EditMovement(int id, [FromBody] CreateMovementDto movementDto)
        //{
        //    var movement = await _context.Movements.FindAsync(id);
        //    if (movement == null) return NotFound();

        //    movement.UserId = movementDto.UserId;
        //    movement.MaterialId = movementDto.MaterialId;
        //    movement.Date = movementDto.Date;
        //    movement.QuantityChanged = movementDto.QuantityChanged;

        //    _context.Movements.Update(movement);
        //    await _context.SaveChangesAsync();
        //    return Ok(true);
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovement(int id)
        {
            var movement = await _context.Movements.FindAsync(id);
            if (movement == null) return NotFound();

            _context.Movements.Remove(movement);
            await _context.SaveChangesAsync();
            return Ok(true);
        }


    }
}
