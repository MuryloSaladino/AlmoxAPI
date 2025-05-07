using MediatR;

namespace Almox.Application.Features.Users.FindById;

public sealed record FindUserByIdRequest(
    string Id
) : IRequest<FindUserByIdResponse>;