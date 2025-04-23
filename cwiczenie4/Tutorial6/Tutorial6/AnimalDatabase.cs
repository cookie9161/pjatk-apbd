using Tutorial6.Models;

namespace Tutorial6;

public static class AnimalDatabase
{
    public static List<Animal> Animals = new List<Animal>()
    {
        new Animal() 
        {
            Id = 1,
            Name = "Dog",
            Category = Category.DOG,
            Mass = 20.0,
            FurrColor = FurrColor.BROWN
        },
        new Animal() 
        {
            Id = 2,
            Name = "Cat",
            Category = Category.CAT,
            Mass = 9.0,
            FurrColor = FurrColor.WHITE
        },
        new Animal() 
        {
            Id = 3,
            Name = "Bird",
            Category = Category.BIRD,
            Mass = 0.5,
            FurrColor = FurrColor.YELLOW
        },
        new Animal() 
        {
            Id = 4,
            Name = "Fish",
            Category = Category.FISH,
            Mass = 0.1,
            FurrColor = FurrColor.BLUE
        }
    };
}