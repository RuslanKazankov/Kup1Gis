namespace Kup1Gis.Domain.DirectorySystem;

public abstract class Folder
{
    protected Folder(string name, Folder? parent = null)
    {
        Name = name;
        Parent = parent;
        var infraPath = Path.GetDirectoryName(typeof(Folder).Assembly.Location)!;
        var dirPath = Path.Combine(infraPath, name);
        DirectoryInfo = new DirectoryInfo(dirPath);
    }

    public DirectoryInfo DirectoryInfo { get; private init; }
    public string Name { get; private set; }

    /// <summary>
    ///     null == root
    /// </summary>
    public Folder? Parent { get; private init; }
}