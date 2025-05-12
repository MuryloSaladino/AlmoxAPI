using MediatR;

namespace Almox.Application.Features.Requests.FindById;

public sealed record FindRequestByIdRequest(
    Guid Id
) : IRequest<FindRequestByIdResponse>;