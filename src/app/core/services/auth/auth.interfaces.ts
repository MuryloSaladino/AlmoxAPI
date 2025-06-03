import { User } from "../../types/entities/user.entity";

export interface LoginRequest {
    userIdentifier: string;
    password: string;
}

export interface LoginResponse {
    user: User;
}
