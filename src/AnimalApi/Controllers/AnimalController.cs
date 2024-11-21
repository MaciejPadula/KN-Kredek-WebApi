using AnimalApi.Models;
using AnimalApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimalApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AnimalController : ControllerBase
{
    private readonly IAnimalService _animalService;

    public AnimalController(IAnimalService animalService)
    {
        _animalService = animalService;
    }

    [HttpGet]
    public IActionResult GetAnimals()
    {
        var animals = _animalService.GetAnimals();
        return Ok(animals);
    }

    [HttpGet]
    public IActionResult GetAnimalsSorted([FromQuery] SortingDirection direction)
    {
        var animals = _animalService.GetAnimalsSorted(direction);
        return Ok(animals);
    }

    [HttpPost]
    public IActionResult AddAnimal([FromBody] Animal animal)
    {
        _animalService.AddAnimal(animal);
        return Ok();
    }

    [HttpPut]
    public IActionResult UpdateAnimal([FromBody] Animal animal)
    {
        _animalService.UpdateAnimal(animal);
        return Ok();
    }

    [HttpGet("{name}")]
    public IActionResult GetAnimal(string name)
    {
        var animal = _animalService.GetAnimal(name);
        if (animal == null)
        {
            return NotFound();
        }
        return Ok(animal);
    }

    [HttpDelete("{name}")]
    public IActionResult DeleteAnimal(string name)
    {
        _animalService.DeleteAnimal(name);
        return Ok();
    }
}
