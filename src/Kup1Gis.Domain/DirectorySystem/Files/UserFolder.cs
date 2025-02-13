using Kup1Gis.Domain.DirectorySystem.Files.User;

namespace Kup1Gis.Domain.DirectorySystem.Files;

public class UserFolder : Folder
{
    public ImageFolder Image { get; }
    public DocumentsFolder Documents { get; }
    internal UserFolder(Folder parent) : base("User", parent)
    {
        Image = new ImageFolder(this);
        Documents = new DocumentsFolder(this);
    }
}