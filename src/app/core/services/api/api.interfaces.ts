import { User } from "../../entities/user.entity";

export interface LoginRequest {
    userIdentifier: string;
    password: string;
}

export interface LoginResponse {
    user: User;
}

export interface Paginated<T> {
    page: number;
    pageSize: number;
    maxPage: number;
    results: T[];
}
