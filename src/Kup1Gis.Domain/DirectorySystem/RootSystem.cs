using Kup1Gis.Domain.DirectorySystem.Files.User;
using Kup1Gis.Domain.DirectorySystem.Interfaces;

namespace Kup1Gis.Domain.DirectorySystem;

public class RootSystem : IImageFolderSource
{
    public RootSystem()
    {
        Files = new FilesFolder();
    }

    public FilesFolder Files { get; }

    public ImageFolder GetImageFolder()
    {
        return Files.UserFolder.Image;
    }
}