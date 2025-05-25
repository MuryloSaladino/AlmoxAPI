using Almox.Domain.Common.Exceptions;

namespace Almox.Application.Contracts;

public interface IExceptionDataExtractor
{
    ExceptionData Extract(Exception ex);
}

public interface IExceptionDataExtractor<TException> : IExceptionDataExtractor
    where TException : Exception
{
    ExceptionData Extract(TException ex);
}

public class DefaultExceptionDataExtractor : IExceptionDataExtractor<Exception>
{
    public ExceptionData Extract(Exception ex) => new(ex);
}