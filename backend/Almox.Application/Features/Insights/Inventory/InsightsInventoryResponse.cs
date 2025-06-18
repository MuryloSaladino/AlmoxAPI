namespace Almox.Application.Features.Insights.Inventory;

public sealed record InsightsInventoryResponse(
    int TotalCategories,
    int TotalItems,
    int TotalStock
);