using Tutorial6.Models;

namespace Tutorial6;

public static class VisitDatabase
{
    public static List<Visit> Visits = new List<Visit>()
    {
        new Visit()
        {
            VisitDate = DateTime.Now,
            Description = "First visit",
            VisitPrice = "100",
            Animal = new Animal()
            {
                Id = 1,
                Name = "Dog",
                Category = Category.DOG,
                Mass = 20.0,
                FurrColor = FurrColor.BROWN
            }
        },
        new Visit()
        {
            VisitDate = DateTime.Now,
            Description = "Second visit",
            VisitPrice = "200",
            Animal = new Animal()
            {
                Id = 1,
                Name = "Dog",
                Category = Category.DOG,
                Mass = 20.0,
                FurrColor = FurrColor.BROWN
            }
        },
        new Visit()
        {
            VisitDate = DateTime.Now,
            Description = "First visit",
            VisitPrice = "300",
            Animal = new Animal()
            {
                Id = 3,
                Name = "Cat",
                Category = Category.CAT,
                Mass = 5,
                FurrColor = FurrColor.YELLOW
            }
        }
    };
}