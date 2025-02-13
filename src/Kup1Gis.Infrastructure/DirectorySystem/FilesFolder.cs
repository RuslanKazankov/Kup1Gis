using Kup1Gis.Infrastructure.DirectorySystem.Files;

namespace Kup1Gis.Infrastructure.DirectorySystem;

public class FilesFolder : Folder
{
    public UserFolder UserFolder { get; }
    internal FilesFolder() : base("Files")
    {
        UserFolder = new UserFolder(this);
    }

}