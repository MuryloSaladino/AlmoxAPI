import type { ItemSummary, ItemCreation, Item } from "@/types/entities/items.types";
import { almoxApi } from ".";
import { Query } from "@/utils/query.utils";

export const ItemsService = {

    url: "/items",

    create: async function(payload: ItemCreation) {
        const response = await almoxApi.post<ItemSummary>(this.url, payload);
        return response.data;
    },

    delete: async function(itemId: string) {
        await almoxApi.delete(`${this.url}/${itemId}`) 
    },

    get: async function(filters: { name?: string, category?: string }) {
        const response = await almoxApi.get<Item>(this.url + Query.fromObject(filters));
        return response.data;
    },

    update: async function(itemId: string, payload: Partial<ItemCreation>) {
        const response = await almoxApi.patch<ItemSummary>(`${this.url}/${itemId}`, payload);
        return response.data;
    },

    categorize: async function(itemId: string, categoryId: string) {
        const response = await almoxApi.post<Item>(`${this.url}/${itemId}/categories/${categoryId}`);
        return response.data;
    },

} as const;