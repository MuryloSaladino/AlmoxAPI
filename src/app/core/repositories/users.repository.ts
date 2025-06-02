import { inject, Injectable } from "@angular/core";
import { User, UserCreation } from "../entities/user.entity";
import { ApiService } from "../services/api/api.service";
import { Paginated } from "../services/api/api.interfaces";

@Injectable({ providedIn: "root" })
export class UsersRepository {

	private readonly api = inject(ApiService);

	create(userCreation: UserCreation) {
		return this.api.post<User>("/users", userCreation);
	}

	get(userId: string) {
		return this.api.get<User>("/users/" + userId);
	}

	getAll() {
		return this.api.get<Paginated<User>>("/users");
	}
}
