using MediatR;

namespace Almox.Application.Features.Users.Count;

public sealed record CountUsersRequest
    : IRequest<CountUsersResponse>;