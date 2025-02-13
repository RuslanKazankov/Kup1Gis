namespace Kup1Gis.Domain.Models.FileModels;

public class ImageModel
{
    public required string FileName { get; init; }
    public required Stream FileStream { get; init; }
    public string? Description { get; init; } = null;
}