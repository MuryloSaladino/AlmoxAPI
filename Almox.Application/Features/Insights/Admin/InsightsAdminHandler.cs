using Almox.Application.Repository.Deliveries;
using Almox.Application.Repository.Departments;
using Almox.Application.Repository.Orders;
using Almox.Application.Repository.Users;
using MediatR;

namespace Almox.Application.Features.Insights.Admin;

public class InsightsAdminHandler(
    IDepartmentsRepository departmentsRepository,
    IDeliveriesRepository deliveriesRepository,
    IOrdersRepository ordersRepository,
    IUsersRepository usersRepository
) : IRequestHandler<InsightsAdminRequest, InsightsAdminResponse>
{
    public async Task<InsightsAdminResponse> Handle(
        InsightsAdminRequest request, CancellationToken cancellationToken)
    {
        var departments = await departmentsRepository.Count(cancellationToken);
        var users = await usersRepository.Count(cancellationToken);
        var orders = await ordersRepository.CountActive(cancellationToken);
        var deliveries = await deliveriesRepository.CountPending(cancellationToken);

        return new(departments, users, orders, deliveries);
    }
}