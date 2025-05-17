import type { Department, DepartmentCreation, DepartmentSummary } from "@/types/entities/departments.types";
import { almoxApi } from ".";
import { Query } from "@/utils/query.utils";

export const DepartmentsService = {

    url: "/departments",

    create: async function(payload: DepartmentCreation) {
        const response = await almoxApi.post<DepartmentSummary>(this.url, payload);
        return response.data;
    },
    
    getById: async function(departmentId: string) {
        const response = await almoxApi.get<Department>(`${this.url}/${departmentId}`);
        return response.data;
    },
    
    get: async function(query?: { name?: string }) {
        const response = await almoxApi.get<DepartmentSummary[]>(`${this.url}${Query.fromObject(query)}`)
        return response.data;
    },
    
    delete: async function(departmentId: string) {
        await almoxApi.delete(`${this.url}/${departmentId}`);
    },

} as const;
