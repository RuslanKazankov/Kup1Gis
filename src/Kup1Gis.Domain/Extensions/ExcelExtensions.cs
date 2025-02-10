namespace Kup1Gis.Domain.Extensions;
using NPOI.SS.UserModel;

public static class ExcelExtensions
{
    public static string GetString(this ICell cell)
    {
        return (cell.ToString() ?? string.Empty).Trim();
    }
    
    public static double? GetDouble(this ICell cell)
    {
        return double.TryParse((cell.ToString() ?? string.Empty).Trim(), out double value) ? value : null;
    }
    
    public static decimal? GetDecimal(this ICell cell)
    {
        return decimal.TryParse((cell.ToString() ?? string.Empty).Trim(), out decimal value) ? value : null;
    }
    
    public static long? GetLong(this ICell cell)
    {
        return long.TryParse((cell.ToString() ?? string.Empty).Trim(), out long value) ? value : null;
    }
}