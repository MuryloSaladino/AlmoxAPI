import { BodyTypeProcessor, FetchError, FetchOptions } from './interfaces';
import { environment } from '../../../environments/environment';
import { StorageKeys } from '../constants/storage-keys';

export async function http<T = never>(
	url: string,
	{
		method = "GET",
		bodyType = "json",
	}: FetchOptions,
	data?: any
): Promise<T> {

	const fetchCall = async () => await fetch(environment.apiUrl + url, {
		method,
		credentials: "include",
		headers: BodyTypeProcessor[bodyType].headers,
		body: BodyTypeProcessor[bodyType].body(data),
	});

	let response = await fetchCall();

	// Try refresh cookie
	if(response.status == 401) {
		const userId = localStorage.getItem(StorageKeys.USERID);

		await fetch(environment.apiUrl + "/auth/refresh/" + userId, {
			method: "POST", credentials: "include"
		});

		response = await fetchCall();
	}

	const responseBody = response.status != 204
		? await response.json()
		: {};

	if(!response.ok)
		throw new FetchError(responseBody.message || "Error fetching data");

	return responseBody as T;
}

http.get = async <T>(url: string, options?: Omit<FetchOptions, "method">) =>
	await http(url, { method: 'GET', ...options }) as T;

http.post = async <T>(url: string, data?: any, options?: Omit<FetchOptions, "method">) =>
	await http(url, { method: 'POST', ...options }, data) as T;

http.put = async <T>(url: string, data?: any, options?: Omit<FetchOptions, "method">) =>
	await http(url, { method: 'PUT', ...options }, data) as T;

http.delete = async <T>(url: string, data?: any, options?: Omit<FetchOptions, "method">) =>
	await http(url, { method: 'DELETE', ...options }, data) as T;
