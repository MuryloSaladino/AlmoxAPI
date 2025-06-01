import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';

@Injectable({ providedIn: 'root' })
export class ApiService {

	private readonly baseUrl = environment.apiUrl;
	private readonly http = inject(HttpClient);

	get<T>(endpoint: string): Observable<T> {
		return this.http.get<T>(this.baseUrl + endpoint, { withCredentials: true });
	}
	post<T>(endpoint: string, data?: unknown): Observable<T> {
		return this.http.post<T>(this.baseUrl + endpoint, data, { withCredentials: true });
	}
	put<T>(endpoint: string, data?: unknown): Observable<T> {
		return this.http.put<T>(this.baseUrl + endpoint, data, { withCredentials: true });
	}
	delete<T>(endpoint: string): Observable<T> {
		return this.http.delete<T>(this.baseUrl + endpoint, { withCredentials: true });
	}
}
