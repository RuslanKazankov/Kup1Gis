namespace Kup1Gis.Domain.Models.FileModels;

public record GetImageModel
{
    public required string FileName { get; init; }
    public required string Path { get; init; }
    public required string Description { get; init; }
}