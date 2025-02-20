using Kup1Gis.Domain.DirectorySystem.Files.User;

namespace Kup1Gis.Domain.DirectorySystem.Files;

public class UserFolder : Folder
{
    internal UserFolder(Folder parent) : base("User", parent)
    {
        Image = new ImageFolder(this);
        Documents = new DocumentsFolder(this);
    }

    public ImageFolder Image { get; }
    public DocumentsFolder Documents { get; }
}