using Almox.Application.Contracts;
using Almox.Domain.Common.Enums;
using Almox.Domain.Common.Messages;
using Almox.Domain.Objects;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Almox.Persistence.Exceptions;

public class DbUpdateErrorSummaryExtractor
    : IErrorSummaryExtractor<DbUpdateException>
{
    public ErrorSummary Extract(DbUpdateException ex)
    {
        if (ex.InnerException is PostgresException psqlEx)
        {
            return psqlEx.SqlState switch
            {
                PostgresErrorCodes.UniqueViolation
                    => new(StatusCode.BadRequest,
                        ExceptionMessages.BadRequest.ValueAlreadyTaken,
                        psqlEx.MessageText),
                PostgresErrorCodes.ForeignKeyViolation
                    => new(StatusCode.NotFound,
                        ExceptionMessages.NotFound.Resource,
                        psqlEx.MessageText),
                PostgresErrorCodes.NotNullViolation
                    => new(StatusCode.BadRequest,
                        ExceptionMessages.BadRequest.NullValue,
                        psqlEx.MessageText),
                _ => new()
            };
        }
        return new();
    }
}