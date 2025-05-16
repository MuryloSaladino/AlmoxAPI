import { almoxApi } from ".";

export interface ILoginRequest {
    username: string;
    password: string;
}

export interface ILoginResponse {
    token: string;
}

export async function login(payload: ILoginRequest) {
    const response = await almoxApi.post<ILoginResponse>("/auth/login", payload);
    return response.data;
}