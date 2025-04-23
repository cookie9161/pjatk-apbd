using Tutorial6.Models;

namespace Tutorial6.Services;

public interface IVisitService
{
    IEnumerable<Visit> GetAnimalVisits(long animalId);
    Visit AddVisit(Visit visit);
}