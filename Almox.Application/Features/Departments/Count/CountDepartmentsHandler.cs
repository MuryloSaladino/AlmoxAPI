using Almox.Application.Repository.Departments;
using MediatR;

namespace Almox.Application.Features.Departments.Count;

public class CountDepartmentsHandler(
    IDepartmentsRepository departmentRepository
) : IRequestHandler<CountDepartmentsRequest, CountDepartmentsResponse>
{
    public async Task<CountDepartmentsResponse> Handle(
        CountDepartmentsRequest request, CancellationToken cancellationToken)
    {
        var count = await departmentRepository.Count(cancellationToken);
        
        return new CountDepartmentsResponse(count);
    }
}