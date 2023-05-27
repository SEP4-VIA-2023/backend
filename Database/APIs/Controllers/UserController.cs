using Logic.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace APIs.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserLogic _logic;
    public UserController(IUserLogic logic)
    {
        _logic = logic;
    }

    [HttpPost("create"), AllowAnonymous]
    public async Task<ActionResult<UserDTO>> CreateUserAsync([FromBody] UserDTO dto)
    {
        try
        {
            UserDTO created = await _logic.CreateUser(dto);

            return Created("User created", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost("login"), AllowAnonymous]
    public async Task<ActionResult<string>> LoginUserAsync([FromBody] UserDTO dto)
    {
        try
        {
            string token = await _logic.LoginUser(dto);

            return Created("User authorized", token);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}