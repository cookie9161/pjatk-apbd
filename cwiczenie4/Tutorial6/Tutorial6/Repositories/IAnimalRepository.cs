using Tutorial6.Models;

namespace Tutorial6.Repositories;

public interface IAnimalRepository
{
    Animal GetAnimalById(long id);
    IEnumerable<Animal> GetAnimals();
    Animal AddAnimal(Animal animal);
    Animal UpdateAnimal(Animal animal);
    void DeleteAnimalById(long id);
    IEnumerable<Animal> GetAnimalsByName(string name);
}