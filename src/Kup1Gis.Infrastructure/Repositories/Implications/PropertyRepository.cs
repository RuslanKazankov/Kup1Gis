using Kup1Gis.Domain.Entity;
using Kup1Gis.Domain.RepoInterfaces;
using Kup1Gis.Infrastructure.Persistance;

namespace Kup1Gis.Infrastructure.Repositories.Implications;

public class PropertyRepository : Repository, IPropertyRepository
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
}