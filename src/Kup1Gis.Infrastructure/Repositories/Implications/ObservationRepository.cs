using Kup1Gis.Domain.Entity.KupEntity;
using Kup1Gis.Domain.RepoInterfaces;
using Kup1Gis.Infrastructure.Persistence;

namespace Kup1Gis.Infrastructure.Repositories.Implications;

public sealed class ObservationRepository : Repository, IObservationRepository
{
    public ObservationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task AddAsync(Observation entity, CancellationToken token = default)
    {
        await Context.Observations.AddAsync(entity, token);
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