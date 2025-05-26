using Almox.Application.Repository.Categories;
using Almox.Domain.Entities;
using Almox.Persistence.Context;

namespace Almox.Persistence.Repository.Categories;

public class CategoriesRepository(
    AlmoxContext context
) : BaseRepository<Category>(context), ICategoriesRepository;
