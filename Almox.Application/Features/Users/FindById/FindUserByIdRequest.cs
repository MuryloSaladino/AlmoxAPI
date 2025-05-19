using MediatR;

namespace Almox.Application.Features.Users.FindById;

public sealed record FindUserByIdRequest(
    Guid UserId
) : IRequest<FindUserByIdResponse>;