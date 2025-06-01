export interface Paginated<T> {
    page: number;
    pageSize: number;
    maxPage: number;
    results: T[];
}
