namespace Kup1Gis.Domain.Extensions;
using NPOI.SS.UserModel;

public static class ExcelExtensions
{
    public static string GetString(this ICell? cell)
    {
        return cell is null ? string.Empty
            : (cell.ToString() ?? string.Empty).Trim();
    }
    
    public static double? GetDouble(this ICell? cell)
    {
        return cell is null ? null :
            double.TryParse((cell.ToString() ?? string.Empty).Trim(), out double value) ? value : null;
    }
    
    public static decimal? GetDecimal(this ICell? cell)
    {
        return cell is null ? null :
            decimal.TryParse((cell.ToString() ?? string.Empty).Trim(), out decimal value) ? value : null;
    }
    
    public static long? GetLong(this ICell? cell)
    {
        return cell is null ? null :
            long.TryParse((cell.ToString() ?? string.Empty).Trim(), out long value) ? value : null;
    }

    public static T? GetValue<T>(this ICell? cell) where T : IParsable<T>
    {
        return cell is null ? default : T.TryParse(cell.ToString(), null, out T? value) ? value : default;
    }
}