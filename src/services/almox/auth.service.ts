import { almoxApi } from ".";

export interface ILoginRequest {
    username: string;
    password: string;
}

export interface ILoginResponse {
    token: string;
}

export const AuthService = {

    url: "/auth",

    login: async function(payload: ILoginRequest) {
        const response = await almoxApi.post<ILoginResponse>(this.url + "/login", payload);
        return response.data;
    },

} as const;
