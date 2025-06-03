namespace Almox.Application.Features.Insights.Admin;

public sealed record InsightsAdminResponse(
    int Departments,
    int Users,
    int OngoingOrders,
    int PendingDeliveries
);