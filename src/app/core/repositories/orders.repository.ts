import { inject, Injectable } from "@angular/core";
import { ApiService } from "../services/api/api.service";
import { Paginated } from "../services/api/api.interfaces";
import { Order, OrderCreation } from "../entities/order.entity";

@Injectable({ providedIn: "root" })
export class OrdersRepository {

	private readonly api = inject(ApiService);

	create(orderCreation: OrderCreation) {
		return this.api.post<Order>("/orders", orderCreation);
	}

	getAll() {
		return this.api.get<Paginated<Order>>("/orders");
	}

	get(orderId: string) {
		return this.api.get<Order>("/orders/" + orderId);
	}

	advanceStatus(orderId: string, observations: string | null) {
		return this.api.post<Order>("/orders/status", { orderId, observations });
	}

	cancel(orderId: string, observations: string) {
		return this.api.delete<Order>("/orders/status", { orderId, observations });
	}
}
