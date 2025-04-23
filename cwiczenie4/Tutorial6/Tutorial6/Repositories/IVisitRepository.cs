using Tutorial6.Models;

namespace Tutorial6.Repositories;

public interface IVisitRepository
{
    IEnumerable<Visit> GetAnimalVisits(long animalId);
    Visit AddVisit(Visit visit);
}