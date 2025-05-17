import type { Category, CategoryCreation } from "@/types/entities/categories.types";
import { almoxApi } from ".";

export const CategoriesService = {

    url: "/categories",

    create: async function(payload: CategoryCreation) {
        const response = await almoxApi.post<Category>(this.url, payload);
        return response.data;
    },

    get: async function() {
        const response = await almoxApi.get<Category[]>(this.url);
        return response.data;
    },

    delete: async function(categoryId: string) {
        await almoxApi.delete(`${this.url}/${categoryId}`);
    }, 

} as const;