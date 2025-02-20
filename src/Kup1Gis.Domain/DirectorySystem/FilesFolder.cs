using Kup1Gis.Domain.DirectorySystem.Files;

namespace Kup1Gis.Domain.DirectorySystem;

public class FilesFolder : Folder
{
    internal FilesFolder() : base("Files")
    {
        UserFolder = new UserFolder(this);
    }

    public UserFolder UserFolder { get; }
}