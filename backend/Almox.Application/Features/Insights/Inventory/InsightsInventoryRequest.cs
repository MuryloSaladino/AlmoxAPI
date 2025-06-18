using MediatR;

namespace Almox.Application.Features.Insights.Inventory;

public sealed record InsightsInventoryRequest
    : IRequest<InsightsInventoryResponse>;