namespace Kup1Gis.Infrastructure.DirectorySystem;

public abstract class Folder
{
    public DirectoryInfo DirectoryInfo { get; private init; }
    public string Name { get; private set; }
    /// <summary>
    /// null == root
    /// </summary>
    public Folder? Parent { get; private init; }
    
    protected Folder(string name, Folder? parent = null)
    {
        Name = name;
        Parent = parent;
        string infraPath = Path.GetDirectoryName(typeof(Infrastructure.DirectorySystem.Folder).Assembly.Location)!;
        string dirPath = Path.Combine(infraPath, name);
        DirectoryInfo = new DirectoryInfo(dirPath);
    }
}