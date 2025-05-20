using Kup1Gis.Domain.Models.Map;

namespace Kup1Gis.Domain.Common;

public static class KrigingHelper
{
    public static double Variogram(double h, double range, double sill)
    {
        return sill * (1.0 - Math.Exp(-h / range));
    }

    public static double Distance(double x1, double y1, double x2, double y2)
    {
        double dx = x1 - x2;
        double dy = y1 - y2;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    public static double[] Interpolate(List<GeoPoint> points, double x, double y, double range = 0.05, double sill = 1)
    {
        int n = points.Count;
        double[,] matrix = new double[n + 1, n + 1];
        double[] rhs = new double[n + 1];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                double d = Distance(points[i].Lon, points[i].Lat, points[j].Lon, points[j].Lat);
                matrix[i, j] = Variogram(d, range, sill);
            }

            matrix[i, n] = 1;
            matrix[n, i] = 1;

            double dTarget = Distance(points[i].Lon, points[i].Lat, x, y);
            rhs[i] = Variogram(dTarget, range, sill);
        }

        matrix[n, n] = 0;
        rhs[n] = 1;

        double[] weights = Solve(matrix, rhs);
        return weights;
    }

    public static double Predict(List<GeoPoint> points, double x, double y)
    {
        var weights = Interpolate(points, x, y);
        double z = 0;
        for (int i = 0; i < points.Count; i++)
            z += weights[i] * points[i].Value;
        return z;
    }

    // Решение СЛАУ методом Гаусса
    private static double[] Solve(double[,] A, double[] b)
    {
        int n = b.Length;
        for (int i = 0; i < n; i++)
        {
            int maxRow = i;
            for (int k = i + 1; k < n; k++)
                if (Math.Abs(A[k, i]) > Math.Abs(A[maxRow, i]))
                    maxRow = k;

            for (int k = i; k < n; k++)
            {
                (A[maxRow, k], A[i, k]) = (A[i, k], A[maxRow, k]);
            }
            (b[maxRow], b[i]) = (b[i], b[maxRow]);

            for (int k = i + 1; k < n; k++)
            {
                double factor = A[k, i] / A[i, i];
                b[k] -= factor * b[i];
                for (int j = i; j < n; j++)
                    A[k, j] -= factor * A[i, j];
            }
        }

        double[] x = new double[n];
        for (int i = n - 1; i >= 0; i--)
        {
            x[i] = b[i] / A[i, i];
            for (int k = i - 1; k >= 0; k--)
                b[k] -= A[k, i] * x[i];
        }

        return x;
    }
}