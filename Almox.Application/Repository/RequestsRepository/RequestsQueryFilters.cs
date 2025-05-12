using Almox.Domain.Common.Enums;

namespace Almox.Application.Repository.RequestsRepository;

public record RequestsQueryFilters(
    Guid? UserId,
    RequestStatus? Status
);