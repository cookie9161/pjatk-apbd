using Tutorial6.Models;

namespace Tutorial6.Repositories;

public class VisitRepositoryImpl : IVisitRepository
{
    private readonly List<Visit> _visits;

    public VisitRepositoryImpl()
    {
        _visits = VisitDatabase.Visits;
    }
    
    public IEnumerable<Visit> GetAnimalVisits(long animalId)
    {
        return _visits.Where(visit => visit.Animal.Id == animalId);
    }

    public Visit AddVisit(Visit visit)
    {
        _visits.Add(visit);
        return visit;
    }
}