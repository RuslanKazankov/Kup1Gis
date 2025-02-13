using Kup1Gis.Domain.Entity;
using Kup1Gis.Domain.RepoInterfaces;
using Kup1Gis.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Kup1Gis.Infrastructure.Repositories.Implications;

public sealed class KupRepository : Repository, IKupRepository
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

    public async Task UpdateAsync(Kup entity, CancellationToken token = default)
    {
        Context.Kups.Update(entity);
        await Context.SaveChangesAsync(token);
    }

    public Task<IReadOnlyList<Kup>> GetAllAsync(CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Kup> FindByNameAsync(string name, CancellationToken token = default)
    {
        var result = await Context.Kups
            .Where(k => k.Name == name)
            .FirstOrDefaultAsync(cancellationToken: token);
        
        if (result == null)
        {
            //Todo: обработать ошибку
            throw new KeyNotFoundException();
        }

        return result;
    }

    public async Task<Kup> FindByIdAsync(long id, CancellationToken token = default)
    {
        var result = await Context.Kups
            .Where(k => k.Id == id)
            .FirstOrDefaultAsync(cancellationToken: token);
        
        if (result == null)
        {
            //Todo: обработать ошибку
            throw new KeyNotFoundException();
        }

        return result;
    }

    public async Task<bool> ContainsNameAsync(string name, CancellationToken token = default)
    {
        return await Context.Kups
            .Where(k => k.Name == name)
            .AnyAsync(cancellationToken: token);
    }

    public async Task<bool> ContainsIdAsync(long id, CancellationToken token = default)
    {
        return await Context.Kups
            .Where(k => k.Id == id)
            .AnyAsync(cancellationToken: token);
    }
}