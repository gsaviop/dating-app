using api.Data;
using api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly DataContext _context;

    public UsersController(DataContext context) 
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsersList()
    {
        return await _context.Users.ToListAsync();
    }

    [HttpGet("{id}")] //api/users/[idNum]
    public async Task<ActionResult<AppUser>> getUser(int id)
    {
        return await _context.Users.FindAsync(id);
    }

}
