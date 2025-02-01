using Kup1Gis.Infrastructure.Persistance;

namespace Kup1Gis.Infrastructure.Repositories;

public abstract class Repository: IDisposable
{
    protected readonly AppDbContext Context;

    protected Repository(AppDbContext context)
    {
        Context = context;
    }

    public void Dispose()
    {
        Context.Dispose();
    }
}