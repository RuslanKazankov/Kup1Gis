using Kup1Gis.Infrastructure.DirectorySystem;

namespace Kup1Gis.Infrastructure.Persistence;

public class FileSystem
{
    public FilesFolder Files { get; }

    public FileSystem()
    {
        Files = new FilesFolder();
    }
}