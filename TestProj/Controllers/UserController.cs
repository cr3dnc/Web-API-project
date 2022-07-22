using Microsoft.AspNetCore.Mvc;
using TestProj.Interfaces.Services;
using TestProj.Models;

namespace TestProj.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("GetAllUsers")]
    public IActionResult GetAllUsers()
    {
        var users = _userService.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("GetUserById/{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = _userService.GetUserById(id);
        return Ok(user);
    }

    [HttpPost("AddUser")]
    public IActionResult AddUser([FromBody] AddUserModel model)
    {
        _userService.AddUser(model.Name, model.Email);
        return Ok();
    }

    [HttpPut("UpdateUser")]
    public IActionResult UpdateUser([FromBody] UpdateUserModel model)
    {
        _userService.UpdateUser(model.Id, model.Name, model.Email, model.Group, model.CarsGarage);
        return Ok();
    }

    [HttpDelete("DeleteUser")]
    public IActionResult DeleteUser([FromBody] DeleteModel model)
    {
        _userService.DeleteUser(model.Id, model.Deleted);
        return Ok();
    }
}