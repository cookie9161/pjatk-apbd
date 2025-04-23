using Tutorial6.Models;

namespace Tutorial6.Services;

public interface IAnimalService
{
    public Animal GetAnimalById(long id);
    public IEnumerable<Animal> GetAnimals();
    public Animal AddAnimal(Animal animal);
    public Animal UpdateAnimal(Animal animal);
    public void DeleteAnimalById(long id);
    public IEnumerable<Animal> GetAnimalsByName(string name);
}