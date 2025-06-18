export type FetchMethod = "GET" | "POST" | "PUT" | "PATCH" | "DELETE";

export interface FetchOptions {
	notifyError?: boolean;
	notifySuccess?: string;
	method?: FetchMethod;
	bodyType?: "json" | "blob"
}

export class FetchError extends Error {}

export interface Paginated<T> {
    page: number;
    pageSize: number;
    maxPage: number;
    results: T[];
}


export const BodyTypeProcessor = {
	"json": {
		headers: { "Content-Type": "application/json" },
		body: (body: any) => JSON.stringify(body),
	},
	"blob": {
		headers: { },
		body: (body: Blob) => {
			const formData = new FormData();
			formData.append("file", body);
			return formData;
		},
	},
}
