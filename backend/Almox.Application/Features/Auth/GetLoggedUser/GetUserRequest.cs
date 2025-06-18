using MediatR;

namespace Almox.Application.Features.Auth.GetLoggedUser;

public sealed record GetLoggedUserRequest : IRequest<GetLoggedUserResponse>;