using System.Reflection;
using Almox.Domain.Objects;

namespace Almox.Application.Contracts;

public interface IErrorSummaryExtractor<TException>
{
    ErrorSummary Extract(TException ex);
}

public class DefaultErrorSummaryExtractor : IErrorSummaryExtractor<Exception>
{
    public ErrorSummary Extract(Exception ex) => new(ex);
}

public class DynamicErrorSummaryExtractorHandler : IErrorSummaryExtractor<Exception>
{
    private readonly object InnerExtractor;
    private readonly MethodInfo ExtractMethod;

    public DynamicErrorSummaryExtractorHandler(object? innerExtractor)
    {
        InnerExtractor = innerExtractor ?? new DefaultErrorSummaryExtractor();
        ExtractMethod = InnerExtractor.GetType().GetMethod("Extract")
            ?? throw new InvalidOperationException("Extractor does not implement Extract method");
    }

    public ErrorSummary Extract(Exception ex)
        => (ErrorSummary)(ExtractMethod.Invoke(InnerExtractor, [ex]) ?? new());
}