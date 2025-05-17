import type { Request, RequestStatus, RequestSummary, RequestUpdate } from "@/types/entities/requests.types";
import { almoxApi } from ".";
import { Query } from "@/utils/query.utils";

export const RequestsService = {

    url: "/requests",

    start: async function() {
        const response = await almoxApi.post<RequestSummary>(this.url);
        return response.data;
    },

    get: async function(filters: { userId: string, status?: RequestStatus }) {
        const response = await almoxApi.get<RequestSummary[]>(this.url + Query.fromObject(filters));
        return response.data;
    },

    getById: async function(requestId: string) {
        const response = await almoxApi.get<Request>(`${this.url}/${requestId}`);
        return response.data;
    },

    addItem: async function(requestId: string, itemId: string) {
        const response = await almoxApi.get<RequestSummary>(`${this.url}/${requestId}/items/${itemId}`)
        return response.data;
    },

    update: async function(requestId: string, payload: RequestUpdate) {
        const response = await almoxApi.put<RequestSummary>(`${this.url}/${requestId}`, payload);
        return response.data;
    },

    updateStatus: async function(requestId: string, status: RequestStatus) {
        const response = await almoxApi.post<RequestSummary>(`${this.url}/${requestId}/status/${status}`);
        return response.data;
    },

} as const;