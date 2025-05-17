import type { BaseEntity } from "./base-entity.types";
import type { ItemRequest } from "./items.types";

export const RequestStatusList = [
    "Draft",
    "Requested",
    "Accepted",
    "Ready",
    "Completed",
    "Canceled"
] as const;

export type RequestStatus = typeof RequestStatusList[number];

export const RequestPriorityList = [
    "Irrelevant",
    "Low",
    "Medium",
    "High",
    "Urgent"
] as const;

export type RequestPriority = typeof RequestStatusList[number];

export type Request = BaseEntity & {
    userId: string;
    observations: string | null;
    priority: RequestPriority;
    status: RequestStatus;
    requestItems: ItemRequest[];
}

export type RequestSummary = Omit<Request, "requestItems">;

export type RequestUpdate = Pick<Request, "priority" | "observations">; 
