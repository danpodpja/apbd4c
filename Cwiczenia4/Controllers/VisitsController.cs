using Cwiczenia4.Data;
using Cwiczenia4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia4.Controllers;

[ApiController]
[Route("api/animals/{animalId}/visits")]
public class VisitsController : ControllerBase
{
    // GET: api/animals/i/visits
    [HttpGet]
    public ActionResult<IEnumerable<Visit>> GetVisits(int animalId)
    {
        if (!Database.Animals.Any(a => a.Id == animalId))
        {
            return NotFound();
        }
        
        var visits = Database.Visits.Where(v => v.AnimalId == animalId).ToList();
        return Ok(visits);
    }

    // POST: api/animals/i/visits
    [HttpPost]
    public ActionResult<Visit> CreateVisit(int animalId, Visit visit)
    {
        if (!Database.Animals.Any(a => a.Id == animalId))
        {
            return NotFound();
        }
        
        visit.Id = Database.Visits.Count > 0 ? Database.Visits.Max(v => v.Id) + 1 : 1;
        visit.AnimalId = animalId;
        Database.Visits.Add(visit);
        
        return CreatedAtAction(nameof(GetVisits), new { animalId = animalId }, visit);
    }
}
