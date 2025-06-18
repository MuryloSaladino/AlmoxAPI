using MediatR;

namespace Almox.Application.Features.Insights.Admin;

public sealed record InsightsAdminRequest
    : IRequest<InsightsAdminResponse>;