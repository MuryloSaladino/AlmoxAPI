using MediatR;

namespace Almox.Application.Features.Users.FindById;

public sealed record FindUserByIdRequest(
    Guid Id
) : IRequest<FindUserByIdResponse>;