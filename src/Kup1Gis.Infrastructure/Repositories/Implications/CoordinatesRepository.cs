using Kup1Gis.Domain.Entity;
using Kup1Gis.Domain.RepoInterfaces;
using Kup1Gis.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Kup1Gis.Infrastructure.Repositories.Implications;

public class CoordinatesRepository : Repository, ICoordinatesRepository
{
    public CoordinatesRepository(AppDbContext context) : base(context)
    {
    }

    public async Task AddAsync(Coordinates entity, CancellationToken token = default)
    {
        await Context.Coordinates.AddAsync(entity, token);
        await Context.SaveChangesAsync(token);
    }

    public async Task<Coordinates> FindAsync(long id, CancellationToken token = default)
    {
        var result = await Context.Coordinates.FindAsync([id], cancellationToken: token);
        if (result == null)
        {
            //Todo: обработать ошибку
            throw new KeyNotFoundException();
        }

        return result;
    }
}