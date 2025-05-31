import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { finalize, Observable, switchMap } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { User } from '../../entities/user.entity';
import { LoginRequest, LoginResponse } from './api.interfaces';
import { Router } from '@angular/router';
import { AppRoutes } from '../../constants/app-routes';

@Injectable({ providedIn: 'root' })
export class ApiService {

	private readonly baseUrl = environment.apiUrl;
	private readonly http = inject(HttpClient);
	private readonly router = inject(Router);

	public readonly user = signal<User | null>(null);
	public readonly isLoading = signal<boolean>(false);

	constructor() { this.getLoggedUser() }

	get<T>(endpoint: string): Observable<T> {
		return this.http.get<T>(this.baseUrl + endpoint);
	}
	post<T>(endpoint: string, data?: unknown): Observable<T> {
		return this.http.post<T>(this.baseUrl + endpoint, data);
	}
	put<T>(endpoint: string, data?: unknown): Observable<T> {
		return this.http.put<T>(this.baseUrl + endpoint, data);
	}
	delete<T>(endpoint: string): Observable<T> {
		return this.http.delete<T>(this.baseUrl + endpoint);
	}

	public login(request: LoginRequest) {
		this.isLoading.set(true);
		this.post<LoginResponse>('/auth/login', request)
			.pipe(finalize(() => this.isLoading.set(false)))
			.subscribe({
				next: ({ user }) => {
					this.user.set(user);
					this.router.navigate([AppRoutes.DASHBOARD]);
				},
				error: (err) => console.error('Login failed', err),
			});
	}

	public logout() {
		this.delete('/auth/logout').pipe(finalize(() => {
			this.user.set(null);
			this.router.navigate([AppRoutes.LOGIN]);
		}))
	}

	private getLoggedUser() {
		this.isLoading.set(true);
		this.get<User>('/auth/user')
			.pipe(finalize(() => this.isLoading.set(false)))
			.subscribe({
				next: (user) => this.user.set(user),
				error: () => this.user.set(null)
			});
	}

	public refresh() {
		return this.post(`/auth/refresh/${this.user()?.id}`).pipe(
			switchMap(() => new Observable<void>(subscriber => {
				subscriber.next();
				subscriber.complete();
			}))
		);
	}
}
