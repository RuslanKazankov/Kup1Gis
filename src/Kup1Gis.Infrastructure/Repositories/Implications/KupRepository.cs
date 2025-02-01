using Kup1Gis.Domain.Entity;
using Kup1Gis.Domain.RepoInterfaces;
using Kup1Gis.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Kup1Gis.Infrastructure.Repositories.Implications;

public class KupRepository : Repository, IKupRepository
{
    public KupRepository(AppDbContext context) : base(context)
    {
    }

    public async Task AddAsync(Kup entity, CancellationToken token = default)
    {
        await Context.Kups.AddAsync(entity, token);
        await Context.SaveChangesAsync(token);
    }

    public async Task<Kup> FindAsync(long id, CancellationToken token = default)
    {
        var result = await Context.Kups.FindAsync([id], cancellationToken: token);
        if (result == null)
        {
            //Todo: обработать ошибку
            throw new KeyNotFoundException();
        }

        return result;
    }
}