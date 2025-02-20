using Kup1Gis.Domain.Entity.KupEntity.ObservationEntity;
using Kup1Gis.Domain.RepoInterfaces;
using Kup1Gis.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Kup1Gis.Infrastructure.Repositories.Implications;

public sealed class KupPropertyRepository : Repository, IKupPropertyRepository
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
        var result = await Context.KupProperties.FindAsync([id], token);
        if (result == null)
            //Todo: обработать ошибку
            throw new KeyNotFoundException();

        return result;
    }

    public async Task UpdateAsync(KupProperty entity, CancellationToken token = default)
    {
        Context.KupProperties.Update(entity);
        await Context.SaveChangesAsync(token);
    }

    public async Task<IReadOnlyList<KupProperty>> GetAllAsync(CancellationToken token = default)
    {
        return await Context.KupProperties.AsNoTracking().ToListAsync(token);
    }
}