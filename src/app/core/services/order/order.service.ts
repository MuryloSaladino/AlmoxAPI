import { Injectable } from "@angular/core";
import { Order, OrderCreation } from "../../interfaces/entities/order.entity";
import { http } from "../../http";
import { Paginated } from "../../http/interfaces";

@Injectable({ providedIn: "root" })
export class OrderService {

	async create(orderCreation: OrderCreation) {
		return await http.post<Order>("/orders", orderCreation);
	}

	async getAll() {
		return await http.get<Paginated<Order>>("/orders");
	}

	async get(orderId: string) {
		return await http.get<Order>("/orders/" + orderId);
	}

	async advanceStatus(orderId: string, observations: string | null) {
		return await http.post<Order>("/orders/status", { orderId, observations });
	}

	async cancel(orderId: string, observations: string) {
		return await http.delete<Order>("/orders/status", { orderId, observations });
	}
}
