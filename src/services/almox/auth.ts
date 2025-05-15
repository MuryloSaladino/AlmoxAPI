import { almoxApi } from ".";

export interface ILoginRequest {
    username: string;
    password: string;
}

export interface ILoginResponse {
    token: string;
}

export async function login(payload: ILoginRequest) {
    return await almoxApi.post<ILoginResponse>("/auth/login", payload);
}