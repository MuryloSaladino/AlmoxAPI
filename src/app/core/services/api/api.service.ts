import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';

type Headers = Record<string, string | string[]> | HttpHeaders;

@Injectable({ providedIn: 'root' })
export class ApiService {

	private readonly baseUrl = environment.apiUrl;
	private readonly http = inject(HttpClient);

	defaultHeaders: Headers = {
		"Content-Type": "application/json",
	}

	get<T>(endpoint: string, headers: Headers = this.defaultHeaders): Observable<T> {
		return this.http.get<T>(this.baseUrl + endpoint, {
			headers,
			withCredentials: true,
		});
	}
	post<T>(endpoint: string, data?: unknown, headers: Headers = this.defaultHeaders): Observable<T> {
		return this.http.post<T>(this.baseUrl + endpoint, data, {
			headers,
			withCredentials: true,
		});
	}
	put<T>(endpoint: string, data?: unknown, headers: Headers = this.defaultHeaders): Observable<T> {
		return this.http.put<T>(this.baseUrl + endpoint, data, {
			headers,
			withCredentials: true,
		});
	}
	delete<T>(endpoint: string, headers: Headers = this.defaultHeaders): Observable<T> {
		return this.http.delete<T>(this.baseUrl + endpoint, {
			headers,
			withCredentials: true,
		});
	}
}
