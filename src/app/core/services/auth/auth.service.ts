import { effect, Injectable, signal } from '@angular/core';
import { User } from '../../types/entities/user.entity';
import { LoginRequest, LoginResponse } from './auth.types';
import { StorageKeys } from '../../constants/storage-keys';
import { http } from '../../http';

@Injectable({ providedIn: 'root' })
export class AuthService {

	readonly user = signal<User | null>(null);

	constructor() {
		effect(
			() => this.user()
				? localStorage.setItem(StorageKeys.USERID, this.user()!.id)
				: localStorage.removeItem(StorageKeys.USERID)
		)
	}

	async login(request: LoginRequest) {
		const { user } = await http.post<LoginResponse>('/auth/login', request);
		this.user.set(user);
	}

	async tryCookiesAuth() {
		try {
			const user = await http.get<User>('/auth/user');
			this.user.set(user);
			return true;
		} catch (error) {
			return false;
		}
	}

	async logout() {
		await http.delete('/auth/logout');
		this.user.set(null);
	}
}
