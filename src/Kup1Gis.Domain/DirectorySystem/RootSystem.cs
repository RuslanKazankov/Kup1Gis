namespace Kup1Gis.Domain.DirectorySystem;

public class RootSystem
{
    public FilesFolder Files { get; }

    public RootSystem()
    {
        Files = new FilesFolder();
    }
}