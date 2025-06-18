export interface AdminInsights {
	departments: number;
	users: number;
	ongoingOrders: number;
	pendingDeliveries: number;
}

export interface InventoryInsights {
	totalCategories: number;
	totalItems: number;
	totalStock: number;
}
