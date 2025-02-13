namespace Kup1Gis.Domain.Services;

public interface IImagesService
{
    Task AddImageToKup(string kupName, Stream imageStream);
    Task<Stream> GetImageStreamForKup(string kupName);
}