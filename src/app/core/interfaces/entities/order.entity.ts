import { OrderPriority } from "../types/order-priority.types";
import { OrderStatus } from "../types/order-status.types";
import { BaseEntity } from "./base.entity";
import { Item } from "./items.types";



export interface Order extends BaseEntity {
    userId: string;
	priority: OrderPriority;
	tracking: string;
	status: OrderStatus;
	observations: string | null;
    orderItems: OrderItem[];
    statusUpdates: OrderStatusUpdate[];
}

export interface OrderStatusUpdate {
    orderId: string;
    updatedById: string;
    updatedAt: Date;
    status: OrderStatus;
    observations: string | null;
}

export interface OrderItem {
    orderId: string;
    itemId: string;
    item: Item;
    quantity: number;
    price: number;
}

export interface OrderCreation {
    priority: OrderPriority;
    observations: string | null;
    orderedItems: {
        itemId: string;
        quantity: number;
    }[]
}
