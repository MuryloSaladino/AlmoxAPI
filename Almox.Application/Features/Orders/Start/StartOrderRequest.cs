using MediatR;

namespace Almox.Application.Features.Orders.Start;

public sealed record StartOrderRequest() 
    : IRequest<StartOrderResponse>;
