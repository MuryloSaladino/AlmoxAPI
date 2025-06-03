export type FetchMethod = "GET" | "POST" | "PUT" | "PATCH" | "DELETE";

export interface FetchOptions {
	notifyError?: boolean;
	notifySuccess?: string;
	method?: FetchMethod;
}

export class FetchError extends Error {}

export interface Paginated<T> {
    page: number;
    pageSize: number;
    maxPage: number;
    results: T[];
}
