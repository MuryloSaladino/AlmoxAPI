using Almox.Application.Contracts;
using Almox.Domain.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Almox.Persistence.Exceptions;

public class DbUpdateExceptionDataExtractor
    : IExceptionDataExtractor<DbUpdateException>
{
    public ExceptionData Extract(DbUpdateException ex)
    {
        if (ex.InnerException is PostgresException psqlEx)
        {
            return psqlEx.SqlState switch
            {
                PostgresErrorCodes.UniqueViolation
                    => new(ExceptionCode.BadRequest,
                        ExceptionMessages.BadRequest.ValueAlreadyTaken,
                        psqlEx.MessageText),
                PostgresErrorCodes.ForeignKeyViolation
                    => new(ExceptionCode.NotFound,
                        ExceptionMessages.NotFound.Resource,
                        psqlEx.MessageText),
                PostgresErrorCodes.NotNullViolation
                    => new(ExceptionCode.BadRequest,
                        ExceptionMessages.BadRequest.NullValue,
                        psqlEx.MessageText),
                _ => new()
            };
        }
        return new();
    }

    public ExceptionData Extract(Exception ex) => Extract((DbUpdateException)ex);
}