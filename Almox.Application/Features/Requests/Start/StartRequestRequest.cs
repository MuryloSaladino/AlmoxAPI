using MediatR;

namespace Almox.Application.Features.Requests.Start;

public sealed record StartRequestRequest() 
    : IRequest<StartRequestResponse>;
