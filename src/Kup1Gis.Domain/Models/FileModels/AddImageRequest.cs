namespace Kup1Gis.Domain.Models.FileModels;

public record AddImageRequest
{
    public long Id { get; set; }
    public required string FileName { get; init; }
    public required Stream FileStream { get; init; }
    public string? Description { get; init; } = null;
}