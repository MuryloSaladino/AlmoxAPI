import { Injectable } from "@angular/core";
import { http } from "../../http";
import { Paginated } from "../../http/interfaces";
import { Delivery, DeliveryCreation } from "../../types/entities/delivery.entity";

@Injectable({ providedIn: "root" })
export class DeliveryService {

	async create(deliveryCreation: DeliveryCreation) {
		return await http.post<Delivery>("/deliveries", deliveryCreation);
	}

	async getAll(query?: string) {
		return await http.get<Paginated<Delivery>>("/deliveries" + query);
	}

	async advanceStatus(deliveryId: string, observations: string | null) {
		return await http.post<Delivery>("/deliveries/status", { deliveryId, observations });
	}

	async cancel(deliveryId: string, observations: string) {
		return await http.delete<Delivery>("/deliveries/status", { deliveryId, observations });
	}
}
