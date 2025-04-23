using Microsoft.AspNetCore.Mvc;
using Tutorial6.Models;
using Tutorial6.Services;

namespace Tutorial6.Controllers;

[Route("api/[controller]")]
public class VisitsController(IVisitService visitService) : ControllerBase
{
    [HttpGet("{animalId}")]
    public IActionResult GetAnimalVisits(long animalId)
    {
        var visits = visitService.GetAnimalVisits(animalId);
        return Ok(visits);
    }
    
    [HttpPost]
    public IActionResult AddVisit([FromBody] Visit visit)
    {
        var addedVisit = visitService.AddVisit(visit);
        return CreatedAtAction(nameof(GetAnimalVisits), new { animalId = addedVisit.Animal.Id }, addedVisit);
    }
}