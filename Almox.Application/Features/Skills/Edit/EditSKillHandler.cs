using AutoMapper;
using MediatR;
using Almox.Application.Common.Exceptions;
using Almox.Domain.Common;
using Almox.Domain.Entities;
using Almox.Domain.Repository;
using Almox.Domain.Repository.AlmoxRepository;

namespace Almox.Application.Features.Almox.Edit;

public sealed class EditSKillHandler(
    IAlmoxRepository AlmoxRepository,
    IUnitOfWork unitOfWork,
    UserSession session,
    IMapper mapper
) : IRequestHandler<EditSkillRequest, EditSkillResponse>
{
    private readonly IAlmoxRepository AlmoxRepository = AlmoxRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly UserSession session = session;
    private readonly IMapper mapper = mapper;

    public async Task<EditSkillResponse> Handle(
        EditSkillRequest request, CancellationToken cancellationToken)
    {
        Guid userId = session.Id ?? throw new AppException("Unauthorized", 401);

        bool exists = await AlmoxRepository.ExistsForUser(
            Guid.Parse(request.Id!), 
            userId, 
            cancellationToken
        );
        if(!exists) {
            throw new AppException("Skill not found", 404);
        }

        var skill = mapper.Map<Skill>(request);
        skill.Id = Guid.Parse(request.Id!);
        skill.UserId = userId;
        AlmoxRepository.Update(skill);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<EditSkillResponse>(skill);
    }
}