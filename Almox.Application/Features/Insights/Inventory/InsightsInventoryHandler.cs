using Almox.Application.Repository.Categories;
using Almox.Application.Repository.Items;
using MediatR;

namespace Almox.Application.Features.Insights.Inventory;

public class InsightsInventoryHandler(
    ICategoriesRepository categoriesRepository,
    IItemsRepository itemsRepository
) : IRequestHandler<InsightsInventoryRequest, InsightsInventoryResponse>
{
    public async Task<InsightsInventoryResponse> Handle(
        InsightsInventoryRequest request, CancellationToken cancellationToken)
    {
        var totalCategories = await categoriesRepository.Count(cancellationToken);
        var totalItems = await itemsRepository.Count(cancellationToken);
        var totalStock = await itemsRepository.CountStock(cancellationToken);

        return new InsightsInventoryResponse(totalCategories, totalItems, totalStock);
    }
}
