using Tutorial6.Models;
using Tutorial6.Repositories;

namespace Tutorial6.Services;

public class VisitServiceImpl(IVisitRepository visitRepository, IAnimalService animalService) : IVisitService
{
    public IEnumerable<Visit> GetAnimalVisits(long animalId)
    {
        var animal = animalService.GetAnimalById(animalId);
        
        

        return visitRepository.GetAnimalVisits(animal.Id);
    }

    public Visit AddVisit(Visit visit)
    {
        try
        {
            animalService.GetAnimalById(visit.Animal.Id);
        }
        catch (KeyNotFoundException e)
        {
            Console.WriteLine("Animal not found, adding a new one");
            animalService.AddAnimal(visit.Animal);
        }

        return visitRepository.AddVisit(visit);
    }
}