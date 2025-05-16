import type { User } from "@/types/entities/user.types";
import { almoxApi } from ".";

export async function getUserById(id: string) {
    const response = await almoxApi.get<User>("/users/" + id);
    return response.data;
}