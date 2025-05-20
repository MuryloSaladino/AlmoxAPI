using Almox.Domain.Objects;

namespace Almox.Application.Contracts;

public interface IErrorSummaryExtractor
{
    ErrorSummary Extract(Exception ex);
}

public interface IErrorSummaryExtractor<TException> : IErrorSummaryExtractor
    where TException : Exception
{
    ErrorSummary Extract(TException ex);
}

public class DefaultErrorSummaryExtractor : IErrorSummaryExtractor<Exception>
{
    public ErrorSummary Extract(Exception ex) => new(ex);
}