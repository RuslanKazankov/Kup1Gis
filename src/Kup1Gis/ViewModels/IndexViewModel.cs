using Kup1Gis.Domain.Models.Kup;

namespace Kup1Gis.ViewModels;

public record IndexViewModel
{
    public IReadOnlyList<PropertyModel> Properties { get; init; } = [];
}