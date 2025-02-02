using Kup1Gis.Domain.Entity;
using Kup1Gis.Domain.RepoInterfaces;
using Kup1Gis.Infrastructure.Persistance;

namespace Kup1Gis.Infrastructure.Repositories.Implications;

public sealed class ObservationRepository : Repository, IObservationRepository
{
    public ObservationRepository(AppDbContext context) : base(context)
    {
    }

    public Task AddAsync(Observation entity, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<Observation> FindAsync(long id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Observation entity, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Observation>> GetAllAsync(CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}