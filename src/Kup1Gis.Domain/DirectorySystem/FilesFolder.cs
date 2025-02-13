using Kup1Gis.Domain.DirectorySystem.Files;

namespace Kup1Gis.Domain.DirectorySystem;

public class FilesFolder : Folder
{
    public UserFolder UserFolder { get; }
    internal FilesFolder() : base("Files")
    {
        UserFolder = new UserFolder(this);
    }

}