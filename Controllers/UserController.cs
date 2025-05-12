using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pruebaMobiles.data;
using pruebaMobiles.DTOs.UserDto;
using pruebaMobiles.Entities;

namespace pruebaMobiles.Controllers;
[ApiController]
[Route("api/[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<ActionResult<List<User>>> getUser()
    {
        var data = await _context.User.ToListAsync();
        return Ok(data);
    }

    [HttpPost]
    public async Task<ActionResult> CreateUser(CreateUserDto user)
    {
        var existUser = await _context.User.AnyAsync(x => x.name == user.name);

        if (existUser)
            return Conflict("El nombre de usuario ya existe.");
        var newUser = new User { name = user.name, password = user.password };
        await _context.User.AddAsync(newUser);
        await _context.SaveChangesAsync();

        return Ok("Usuario agregado exitosamente.");
    }
    [HttpGet("{id:int}")]
    public async Task<ActionResult<User>> GetUserById(int id)
    {
        var user = await _context.User.FindAsync(id); 

        if (user == null)
            return NotFound($"No se encontró un usuario con el id {id}.");

        return Ok(user);
    }



}

