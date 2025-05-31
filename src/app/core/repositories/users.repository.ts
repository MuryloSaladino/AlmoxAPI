import { inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { User, UserCreation } from "../entities/user.entity";
import { ApiService } from "../services/api/api.service";

@Injectable({ providedIn: "root" })
export class UsersRepository {

	private readonly almoxService = inject(ApiService);

	public create(userCreation: UserCreation): Observable<User> {
		return this.almoxService.post<User>("/users", userCreation);
	}

	public get(userId: string): Observable<User> {
		return this.almoxService.get<User>("/users/" + userId);
	}

	public getAll(): Observable<User[]> {
		return this.almoxService.get<User[]>("/users");
	}
}
