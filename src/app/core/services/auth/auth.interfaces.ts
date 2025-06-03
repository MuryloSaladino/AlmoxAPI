import { User } from "../../interfaces/entities/user.entity";

export interface LoginRequest {
    userIdentifier: string;
    password: string;
}

export interface LoginResponse {
    user: User;
}
