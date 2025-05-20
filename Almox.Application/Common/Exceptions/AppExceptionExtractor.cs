using Almox.Application.Contracts;
using Almox.Domain.Objects;

namespace Almox.Application.Common.Exceptions;

public class AppExceptionExtractor : IErrorSummaryExtractor<AppException>
{
    public ErrorSummary Extract(AppException ex) => new(ex.Status, ex.Message, ex.Details);
    public ErrorSummary Extract(Exception ex) => Extract((AppException)ex);
}