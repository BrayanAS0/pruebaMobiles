using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pruebaMobiles.DTOs.UserDto;

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
        var data = await _context.Users.ToListAsync();
        return Ok(data);
    }

    [HttpPost]
    public async Task<ActionResult> CreateUser(CreateUserDto User)
    {
        var existUser = await _context.Users.AnyAsync(x => x.Name == User.name);

        if (existUser)
            return Conflict("El nombre de usuario ya existe.");
        var newUser = new User { Name = User.name, Password = User.password };
        await _context.Users.AddAsync(newUser);
        await _context.SaveChangesAsync();

        return Ok("Usuario agregado exitosamente.");
    }
    [HttpGet("{id:int}")]
    public async Task<ActionResult<User>> GetUserById(int id)
    {
        var User = await _context.Users.FindAsync(id); 

        if (User == null)
            return NotFound($"No se encontró un usuario con el id {id}.");

        return Ok(User);
    }

    [HttpGet("{usuario}/{contraseña}")]
    public async Task<ActionResult> Login(string usuario,string contraseña)
    {
        var User = await _context.Users.FirstOrDefaultAsync(x => x.Name == usuario && x.Password == contraseña);

        return Ok(User);
    }


}

