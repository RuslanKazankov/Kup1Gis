using Kup1Gis.Domain.Entity;
using Kup1Gis.Domain.RepoInterfaces;
using Kup1Gis.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Kup1Gis.Infrastructure.Repositories.Implications;

public sealed class PropertyRepository : Repository, IPropertyRepository
{
    public PropertyRepository(AppDbContext context) : base(context)
    {
    }

    public async Task AddAsync(Property entity, CancellationToken token = default)
    {
        await Context.Properties.AddAsync(entity, token);
        await Context.SaveChangesAsync(token);
    }

    public async Task<Property> FindAsync(long id, CancellationToken token = default)
    {
        var result = await Context.Properties.FindAsync([id], cancellationToken: token);
        if (result == null)
        {
            //Todo: обработать ошибку
            throw new KeyNotFoundException();
        }

        return result;
    }

    public async Task UpdateAsync(Property entity, CancellationToken token = default)
    {
        Context.Properties.Update(entity);
        await Context.SaveChangesAsync(token);
    }

    public async Task<IReadOnlyList<Property>> GetAllAsync(CancellationToken token = default)
    {
        return await Context.Properties.AsNoTracking().ToListAsync(token);
    }

    public async Task<Property> FindByNameAsync(string name, CancellationToken token = default)
    {
        var result = await Context.Properties
            .Where(k => k.Name == name)
            .FirstOrDefaultAsync(cancellationToken: token);
        
        if (result == null)
        {
            //Todo: обработать ошибку
            throw new KeyNotFoundException();
        }

        return result;
    }
}