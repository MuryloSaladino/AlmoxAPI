namespace Almox.Application.Repository;

public record PaginatedFilter
{
    public int Page { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public record PaginatedResult<TData>(
    int Page,
    int PageSize,
    int MaxPage,
    List<TData> Results
);
