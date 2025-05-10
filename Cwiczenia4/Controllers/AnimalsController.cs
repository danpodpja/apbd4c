using Cwiczenia4.Data;
using Cwiczenia4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia4.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimalsController : ControllerBase
{
    // GET: api/animals
    [HttpGet]
    public ActionResult<IEnumerable<Animal>> GetAnimals()
    {
        return Ok(Database.Animals);
    }

    // GET: api/animals/i
    [HttpGet("{id}")]
    public ActionResult<Animal> GetAnimal(int id)
    {
        var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
        
        if (animal == null)
        {
            return NotFound();
        }
        
        return Ok(animal);
    }

    // GET: api/animals/search?name=
    [HttpGet("search")]
    public ActionResult<IEnumerable<Animal>> SearchByName([FromQuery] string name)
    {
        var animals = Database.Animals.Where(a => a.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        return Ok(animals);
    }

    // POST: api/animals
    [HttpPost]
    public ActionResult<Animal> CreateAnimal(Animal animal)
    {
        animal.Id = Database.Animals.Count > 0 ? Database.Animals.Max(a => a.Id) + 1 : 1;
        Database.Animals.Add(animal);
        
        return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
    }

    // PUT: api/animals/i
    [HttpPut("{id}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        if (id != animal.Id)
        {
            return BadRequest();
        }
        
        var existingAnimal = Database.Animals.FirstOrDefault(a => a.Id == id);
        
        if (existingAnimal == null)
        {
            return NotFound();
        }
        
        existingAnimal.Name = animal.Name;
        existingAnimal.Category = animal.Category;
        existingAnimal.Weight = animal.Weight;
        existingAnimal.FurColor = animal.FurColor;
        
        return NoContent();
    }

    // DELETE: api/animals/i
    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
        
        if (animal == null)
        {
            return NotFound();
        }
        
        Database.Animals.Remove(animal);
        
        Database.Visits.RemoveAll(v => v.AnimalId == id);
        
        return NoContent();
    }
}
