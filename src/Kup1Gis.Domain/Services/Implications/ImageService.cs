using Kup1Gis.Domain.DirectorySystem;

namespace Kup1Gis.Domain.Services.Implications;

public class ImageService : IImagesService
{
    private readonly RootSystem _rootSystem;
    
    public ImageService(RootSystem rootSystem)
    {
        _rootSystem = rootSystem;
    }

    public Task AddImageToKup(string kupName, Stream imageStream)
    {
        throw new NotImplementedException();
    }

    public Task<Stream> GetImageStreamForKup(string kupName)
    {
        throw new NotImplementedException();
    }
}