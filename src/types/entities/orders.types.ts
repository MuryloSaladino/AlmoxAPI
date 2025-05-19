import type { BaseEntity } from "./base-entity.types";
import type { ItemOrder } from "./items.types";

export const OrderStatusList = [
    "Draft",
    "Requested",
    "Accepted",
    "Ready",
    "Completed",
    "Canceled"
] as const;

export type OrderStatus = typeof OrderStatusList[number];

export const OrderPriorityList = [
    "Irrelevant",
    "Low",
    "Medium",
    "High",
    "Urgent"
] as const;

export type OrderPriority = typeof OrderStatusList[number];

export type Order = BaseEntity & {
    userId: string;
    observations: string | null;
    priority: OrderPriority;
    status: OrderStatus;
    orderItems: ItemOrder[];
}

export type OrderSummary = Omit<Order, "orderItems">;

export type OrderUpdate = Pick<Order, "priority" | "observations">; 
