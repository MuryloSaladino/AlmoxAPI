using AutoMapper;
using MediatR;
using Almox.Application.Common.Exceptions;
using Almox.Domain.Common;
using Almox.Domain.Entities;
using Almox.Domain.Repository;
using Almox.Domain.Repository.AlmoxRepository;
using Almox.Domain.Repository.UsersRepository;

namespace Almox.Application.Features.Almox.Create;

public sealed class CreateSkillHandler(
    IAlmoxRepository AlmoxRepository,
    IUsersRepository userRepository,
    IUnitOfWork unitOfWork,
    UserSession session,
    IMapper mapper
) : IRequestHandler<CreateSkillRequest, CreateSkillResponse>
{
    private readonly IAlmoxRepository AlmoxRepository = AlmoxRepository;
    private readonly IUsersRepository userRepository = userRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly UserSession session = session;
    private readonly IMapper mapper = mapper;

    public async Task<CreateSkillResponse> Handle(
        CreateSkillRequest request, CancellationToken cancellationToken)
    {
        var skill = mapper.Map<Skill>(request);
        var userId = session.Id ?? throw new AppException("Unauthorized", 401);
        var user = await userRepository.Get(userId, cancellationToken)
            ?? throw new AppException("User not found", 404);
        
        skill.User = user;
        skill.UserId = userId;
            
        AlmoxRepository.Create(skill);
        
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateSkillResponse>(skill);
    }
}