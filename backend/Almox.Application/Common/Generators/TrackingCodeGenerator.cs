namespace Almox.Application.Common.Generators;

public static class TrackingCodeGenerator
{
    public static string Generate()
    {
        var date = DateTime.UtcNow.ToString("yyyyMMdd");
        var random = Guid.NewGuid().ToString("N")[..6].ToUpper();

        return $"TK{date}{random}";
    }
}