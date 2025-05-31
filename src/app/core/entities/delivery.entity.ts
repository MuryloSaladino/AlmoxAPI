import { DeliveryStatus } from "../types/delivery-status";
import { BaseEntity } from "./base.entity";
import { Item } from "./items.types";


export interface DeliveryStatusUpdate {
    deliveryId: string;
    updatedById: string;
    updatedAt: Date;
    status: DeliveryStatusUpdate;
    observations: string | null;
}

export interface DeliveryItem {
    deliveryId: string;
    itemId: string;
    item: Item;
    quantity: number;
    supplierPrice: number;
}

export interface Delivery extends BaseEntity {
    supplier: string;
	tracking: string;
	expectedDate: Date;
	status: DeliveryStatus;
    deliveryItems: DeliveryItem[];
    statusUpdated: DeliveryStatusUpdate;
}
