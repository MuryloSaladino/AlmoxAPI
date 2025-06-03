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
        var departments = departmentsRepository.Count(cancellationToken);
        var users = usersRepository.Count(cancellationToken);
        var orders = ordersRepository.CountActive(cancellationToken);
        var deliveries = deliveriesRepository.CountPending(cancellationToken);

        return new(
            await departments, 
            await users, 
            await orders, 
            await deliveries
        );
    }
}