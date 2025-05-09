using MediatR;

namespace Almox.Application.Features.Requests.Create;

public sealed record CreateRequestRequest() : IRequest<CreateRequestResponse>;
