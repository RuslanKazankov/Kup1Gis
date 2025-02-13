using Kup1Gis.Infrastructure.DirectorySystem;

namespace Kup1Gis.Infrastructure.Persistence;

public class DirectorySystem
{
    public FilesFolder Files { get; }

    public DirectorySystem()
    {
        Files = new FilesFolder();
    }
}