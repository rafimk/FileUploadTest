using FileUploadTest.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileUploadTest.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private static readonly List<User> _users = new List<User>();
    
    public UsersController()
    {
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> Get()
    {
        await Task.CompletedTask;
        return Ok(_users);
    }
    
    [HttpGet("{userId:guid}")]
    public async Task<ActionResult<IEnumerable<User>>> Get(Guid userId)
    {
        await Task.CompletedTask;
        return Ok(_users.Where(x => x.Id == userId));
    }

    [HttpPost]
    public async Task<ActionResult> Post(User user)
    {
        user.Id = Guid.NewGuid();
        _users.Add(user);
        await Task.CompletedTask;
        return CreatedAtAction(nameof(Get), new {user.Id}, null);
    }
}