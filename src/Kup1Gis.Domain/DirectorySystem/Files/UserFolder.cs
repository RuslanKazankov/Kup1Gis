using Kup1Gis.Domain.DirectorySystem.Files.User;

namespace Kup1Gis.Domain.DirectorySystem.Files;

public class UserFolder : Folder
{
    public ImagesFolder Images { get; }
    public DocumentsFolder Documents { get; }
    internal UserFolder(Folder parent) : base("User", parent)
    {
        Images = new ImagesFolder(this);
        Documents = new DocumentsFolder(this);
    }
}