using Cwiczenia4.Models;

namespace Cwiczenia4.Data;

public static class Database
{
    public static List<Animal> Animals { get; set; } = new List<Animal>
    {
        new Animal { Id = 1, Name = "Bolo", Category = "Pies", Weight = 15.5, FurColor = "Brązowy" },
        new Animal { Id = 2, Name = "Mruczek", Category = "Kot", Weight = 4.2, FurColor = "Czarny" },
        new Animal { Id = 3, Name = "Lolo", Category = "Pies", Weight = 25.0, FurColor = "Biały" }
    };

    public static List<Visit> Visits { get; set; } = new List<Visit>
    {
        new Visit { Id = 1, AnimalId = 1, VisitDate = DateTime.Now.AddDays(-5), Description = "Szczepienie", Price = 150.00m },
        new Visit { Id = 2, AnimalId = 2, VisitDate = DateTime.Now.AddDays(-2), Description = "Badanie kontrolne", Price = 100.00m },
        new Visit { Id = 3, AnimalId = 1, VisitDate = DateTime.Now.AddDays(-1), Description = "Odrobaczanie", Price = 80.00m }
    };
}
