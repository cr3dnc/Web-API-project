using Microsoft.AspNetCore.Mvc;
using TestProj.Interfaces.Services;
using TestProj.Models;

namespace TestProj.Controllers;

[ApiController]
[Route("[controller]")]
public class GroupController : Controller
{
    private readonly IGroupService _groupService;

    public GroupController(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpGet("GetAllGroups")]
    public IActionResult GetAllGroups()
    {
        var groups = _groupService.GetAllGroups();
        return Ok(groups);
    }

    [HttpGet("GetGroupById/{id}")]
    public IActionResult GetGroupById(int id)
    {
        var group = _groupService.GetGroupById(id);
        return Ok(group);
    }

    [HttpPost("AddGroup")]
    public IActionResult AddGroup([FromBody] AddGroupModel model)
    {
        _groupService.AddGroup(model.Name);
        return Ok();
    }

    [HttpPut("UpdateGroup")]
    public IActionResult UpdateGroup([FromBody] UpdateGroupModel model)
    {
        _groupService.UpdateGroup(model.Id, model.Name);
        return Ok();
    }

    [HttpDelete("DeleteGroup")]
    public IActionResult DeleteGroup([FromBody] DeleteModel model)
    {
        _groupService.DeleteGroup(model.Id, model.Deleted);
        return Ok();
    }
}