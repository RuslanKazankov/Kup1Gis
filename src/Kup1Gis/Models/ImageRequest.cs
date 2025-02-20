namespace Kup1Gis.Models;

public record ImageRequest
{
    public required IFormFile Image { get; init; }
    public string? Title { get; init; }
    public string? Description { get; init; }
}