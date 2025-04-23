using Microsoft.AspNetCore.Mvc;
using Tutorial6.Models;
using Tutorial6.Services;

namespace Tutorial6.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController(IAnimalService animalService) : ControllerBase
    {
        
        [HttpGet]
        public IActionResult GetAnimals()
        {
            var animals = animalService.GetAnimals();
            return Ok(animals);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetAnimalById(int id)
        {
            return Ok(animalService.GetAnimalById(id));
        }
        
        [HttpGet("search")]
        public IActionResult GetAnimalsByName([FromQuery] string name)
        {
            var animals = animalService.GetAnimalsByName(name);
            return Ok(animals);
        }
        
        [HttpPost]
        public IActionResult AddAnimal([FromBody] Animal animal)
        {
            animalService.AddAnimal(animal);
            return Created(animal.Id.ToString(), animal);
        }
        
        [HttpPut]
        public IActionResult UpdateAnimal([FromBody] Animal animal)
        {
            var updatedAnimal = animalService.UpdateAnimal(animal);
            return Ok(updatedAnimal);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteAnimalById(long id)
        {
            animalService.DeleteAnimalById(id);
            return NoContent();
        }
    }

