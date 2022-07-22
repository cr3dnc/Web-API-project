using Microsoft.AspNetCore.Mvc;
using TestProj.Interfaces.Services;
using TestProj.Models;

namespace TestProj.Controllers;

[ApiController]
[Route("[controller]")]
public class CarsGarageController : Controller
{
    private readonly ICarsGarageService _carsGarageService;

    public CarsGarageController(ICarsGarageService carsGarageService)
    {
        _carsGarageService = carsGarageService;
    }

    [HttpGet("GetAllCarsGarages")]
    public IActionResult GetAllCarsGarages()
    {
        var users = _carsGarageService.GetAllCarsGarages();
        return Ok(users);
    }

    [HttpGet("GetCarsGarageById/{id}")]
    public IActionResult GetCarsGarageById(int id)
    {
        var user = _carsGarageService.GetCarsGarageById(id);
        return Ok(user);
    }

    [HttpPost("AddCarsGarage")]
    public IActionResult AddCarsGarage([FromBody] AddCarsGarageModel model)
    {
        _carsGarageService.AddCarsGarage(model.Name);
        return Ok();
    }

    [HttpPut("UpdateCarsGarage")]
    public IActionResult UpdateCarsGarage([FromBody] UpdateCarsGarageModel model)
    {
        _carsGarageService.UpdateCarsGarage(model.Id, model.Name);
        return Ok();
    }

    [HttpDelete("DeleteCarsGarage")]
    public IActionResult DeleteCarsGarage([FromBody] DeleteModel model)
    {
        _carsGarageService.DeleteCarsGarage(model.Id, model.Deleted);
        return Ok();
    }
}