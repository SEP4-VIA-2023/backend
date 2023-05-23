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
    public ActionResult<UserDTO> CreateUser([FromBody] UserDTO dto)
    {
        try
        {
            UserDTO created = _logic.CreateUser(dto);

            return Created("User created", created);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPost("login"), AllowAnonymous]
    public ActionResult<string> LoginUser([FromBody] UserDTO dto)
    {
        try
        {
            string token = _logic.LoginUser(dto);

            return Created("User authorized", token);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}