using Tutorial6.Models;
using Tutorial6.Repositories;

namespace Tutorial6.Services;

public class AnimalServiceImpl(IAnimalRepository animalRepository) : IAnimalService
{
    public Animal GetAnimalById(long id)
    {
        var animal = FindAnimalById(id);
        return animal;
    }

    public IEnumerable<Animal> GetAnimals()
    {
        return animalRepository.GetAnimals();
    }

    public Animal AddAnimal(Animal animal)
    {
        CheckAnimalName(animal.Name);
        CheckAnimalMass(animal.Mass);

        return animalRepository.AddAnimal(animal);
    }

    public Animal UpdateAnimal(Animal animal)
    {
        CheckAnimalName(animal.Name);
        CheckAnimalMass(animal.Mass);
        var existingAnimal = FindAnimalById(animal.Id);
        
        existingAnimal.Name = animal.Name;
        existingAnimal.Mass = animal.Mass;
        existingAnimal.Category = animal.Category;
        existingAnimal.FurrColor = animal.FurrColor;
        
        return animalRepository.UpdateAnimal(existingAnimal);
    }

    public void DeleteAnimalById(long id)
    {
        var animal = FindAnimalById(id);
        animalRepository.DeleteAnimalById(animal.Id);
    }

    public IEnumerable<Animal> GetAnimalsByName(string name)
    {
        CheckAnimalName(name);
        var animals = animalRepository.GetAnimalsByName(name);
        return animals;
    }
    
    private Animal FindAnimalById(long id)
    {
        var animal = animalRepository.GetAnimalById(id);
        
        if (animal == null)
        {
            throw new KeyNotFoundException($"Animal with id {id} not found");
        }

        return animal;
    }
    
    private void CheckAnimalName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Animal name cannot be null or empty");
        }
    }
    
    private void CheckAnimalMass(double mass)
    {
        if (mass <= 0)
        {
            throw new ArgumentException("Animal mass must be greater than zero");
        }
    }
}