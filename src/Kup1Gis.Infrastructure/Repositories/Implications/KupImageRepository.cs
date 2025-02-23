using Kup1Gis.Domain.Entity.KupEntity;
using Kup1Gis.Domain.RepoInterfaces;
using Kup1Gis.Infrastructure.Persistence;

namespace Kup1Gis.Infrastructure.Repositories.Implications;

public class KupImageRepository : Repository, IKupImageRepository
{
    public KupImageRepository(AppDbContext context) : base(context)
    {
    }

    public async Task AddAsync(KupImage entity, CancellationToken token = default)
    {
        await Context.KupImages.AddAsync(entity, token);
    }

    public Task<KupImage> FindAsync(long id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(KupImage entity, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<KupImage>> GetAllAsync(CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(KupImage entity, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}