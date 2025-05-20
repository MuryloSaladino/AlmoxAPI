using Almox.Application.Common.Exceptions;
using Almox.Application.Common.Session;
using Almox.Application.Repository;
using Almox.Application.Repository.CategoriesRepository;
using Almox.Domain.Common.Messages;
using Almox.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Almox.Application.Features.Categories.Create;

public class CreateCategoryHandler(
    ICategoriesRepository categoriesRepository,
    IRequestSession requestSession,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateCategoryRequest, CreateCategoryResponse>
{
    public async Task<CreateCategoryResponse> Handle(
        CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var session = requestSession.GetSessionOrThrow();

        if (!session.IsAdmin)
            throw AppException.Forbidden(ExceptionMessages.Forbidden.Admin);

        var category = mapper.Map<Category>(request);
        
        categoriesRepository.Create(category);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateCategoryResponse>(category);
    }
}