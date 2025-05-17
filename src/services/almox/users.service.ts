import type { User, UserCreation } from "@/types/entities/user.types";
import { almoxApi } from ".";
import { Query } from "@/utils/query.utils";

export const UsersService = {

    url: "/users",

    register: async function(payload: UserCreation) {
        const response = await almoxApi.post<User>(this.url, payload);
        return response.data;
    },

    getById: async function(userId: string) {
        const response = await almoxApi.get<User>(`${this.url}/${userId}`);
        return response.data;
    },

    get: async function(filters: { username?: string, email?: string }) {
        const response = await almoxApi.get<User[]>(this.url + Query.fromObject(filters));
        return response.data;
    },

    grantAdmin: async function(userId: string) {
        const response = await almoxApi.post(`${this.url}/promote/${userId}`);
        return response.data;
    },

} as const;
