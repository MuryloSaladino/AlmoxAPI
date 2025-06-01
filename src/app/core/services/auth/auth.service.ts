import { inject, Injectable } from '@angular/core';
import { BehaviorSubject, finalize, tap } from 'rxjs';
import { User } from '../../entities/user.entity';
import { LoginRequest, LoginResponse } from './auth.interfaces';
import { ApiService } from '../api/api.service';

@Injectable({ providedIn: 'root' })
export class AuthService {

	readonly api = inject(ApiService);
	readonly userSubject = new BehaviorSubject<User | null>(null);

	login(request: LoginRequest) {
		return this.api.post<LoginResponse>('/auth/login', request).pipe(tap(
			({ user }) => this.userSubject.next(user)
		));
	}

	logout() {
		return this.api.delete('/auth/logout').pipe(finalize(() =>
			this.userSubject.next(null)
		))
	}

	tryCookiesAuth() {
		return this.api.get<User>('/auth/user').pipe(tap(
			user => this.userSubject.next(user)
		));
	}

	refresh() {
		return this.api.post(`/auth/refresh/${this.userSubject.value?.id}`, {});
	}
}
