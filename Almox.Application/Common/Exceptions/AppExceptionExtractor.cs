using Almox.Application.Contracts;
using Almox.Domain.Common.Exceptions;

namespace Almox.Application.Common.Exceptions;

public class AppExceptionExtractor : IExceptionDataExtractor<AppException>
{
    public ExceptionData Extract(AppException ex) => new(ex.Code, ex.Message, ex.Details);
    public ExceptionData Extract(Exception ex) => Extract((AppException)ex);
}