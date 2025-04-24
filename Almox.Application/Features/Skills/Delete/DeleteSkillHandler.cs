using MediatR;
using Almox.Application.Common.Exceptions;
using Almox.Domain.Repository;
using Almox.Domain.Repository.AlmoxRepository;

namespace Almox.Application.Features.Almox.Delete;

public sealed class DeleteSkillHandler(
    IAlmoxRepository AlmoxRepository,
    IUnitOfWork unitOfWork
) : IRequestHandler<DeleteSkillRequest, DeleteSkillResponse>
{
    private readonly IAlmoxRepository AlmoxRepository = AlmoxRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<DeleteSkillResponse> Handle(
        DeleteSkillRequest request, CancellationToken cancellationToken)
    {
        var skill = await AlmoxRepository.Get(Guid.Parse(request.Id), cancellationToken) 
            ?? throw new AppException("Skill not found", 404);

        AlmoxRepository.Delete(skill);

        await unitOfWork.Save(cancellationToken);

        return new DeleteSkillResponse();
    }
}