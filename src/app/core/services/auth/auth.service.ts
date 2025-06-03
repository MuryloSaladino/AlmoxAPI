import { Injectable, signal } from '@angular/core';
import { User } from '../../types/entities/user.entity';
import { LoginRequest, LoginResponse } from './auth.interfaces';
import { StorageKeys } from '../../constants/storage-keys';
import { http } from '../../http';

@Injectable({ providedIn: 'root' })
export class AuthService {

	readonly user = signal<User | null>(null);

	private saveUser(user: User) {
		this.user.set(user);
		localStorage.setItem(StorageKeys.USERID, user.id);
	}

	async login(request: LoginRequest) {
		const { user } = await http.post<LoginResponse>('/auth/login', request);
		this.saveUser(user);
	}

	async tryCookiesAuth() {
		try {
			const user = await http.get<User>('/auth/user');
			this.saveUser(user);
			return true;
		} catch (error) {
			return false;
		}
	}

	logout() {
		http.delete('/auth/logout');
		this.user.set(null);
		localStorage.removeItem(StorageKeys.USERID);
	}
}
