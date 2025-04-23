using Tutorial6.Models;

namespace Tutorial6.Repositories;

public class AnimalRepositoryImpl : IAnimalRepository
{
    private readonly List<Animal> _animals;
 
    public AnimalRepositoryImpl()
    {
        _animals = AnimalDatabase.Animals;
    }
    
    public Animal GetAnimalById(long id)
    {
        return _animals.FirstOrDefault(animal => animal.Id == id);
    }

    public IEnumerable<Animal> GetAnimals()
    {
        return _animals;
    }

    public Animal AddAnimal(Animal animal)
    {
        var maxId = _animals.Max(a => a.Id);
        animal.Id = maxId + 1;
        _animals.Add(animal);
        return animal;
    }

    public Animal UpdateAnimal(Animal animal)
    {
        var index = _animals.FindIndex(a => a.Id == animal.Id);
        
        return _animals[index] = animal;
    }

    public void DeleteAnimalById(long id)
    {
        _animals.RemoveAll(a => a.Id == id);
    }

    public IEnumerable<Animal> GetAnimalsByName(string name)
    {
        return _animals.Where(a => a.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
    }
}