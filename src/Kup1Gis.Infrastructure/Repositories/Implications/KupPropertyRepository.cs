using Kup1Gis.Domain.Entity;
using Kup1Gis.Domain.RepoInterfaces;
using Kup1Gis.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Kup1Gis.Infrastructure.Repositories.Implications;

public class KupPropertyRepository : Repository, IKupPropertyRepository
{
    public KupPropertyRepository(AppDbContext context) : base(context)
    {
    }

    public async Task AddAsync(KupProperty entity, CancellationToken token = default)
    {
        await Context.KupProperties.AddAsync(entity, token);
        await Context.SaveChangesAsync(token);
    }

    public async Task<KupProperty> FindAsync(long id, CancellationToken token = default)
    {
        var result = await Context.KupProperties.FindAsync([id], cancellationToken: token);
        if (result == null)
        {
            //Todo: обработать ошибку
            throw new KeyNotFoundException();
        }

        return result;
    }
}