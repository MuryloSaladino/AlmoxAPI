using Almox.Application.Repository.Categories;
using Almox.Domain.Entities;
using Almox.Persistence.Context;

namespace Almox.Persistence.Repository.Categories;

public class CategoriesRepository(
    AlmoxContext almoxContext
) : BaseRepository<Category>(almoxContext), ICategoriesRepository {}
