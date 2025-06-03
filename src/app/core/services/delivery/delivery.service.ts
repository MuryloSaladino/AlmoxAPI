import { Injectable } from "@angular/core";
import { Delivery, DeliveryCreation } from "../../interfaces/entities/delivery.entity";
import { http } from "../../http";
import { Paginated } from "../../http/interfaces";

@Injectable({ providedIn: "root" })
export class DeliveryService {

	async create(deliveryCreation: DeliveryCreation) {
		return await http.post<Delivery>("/deliveries", deliveryCreation);
	}

	async getAll() {
		return await http.get<Paginated<Delivery>>("/deliveries");
	}

	async advanceStatus(deliveryId: string, observations: string | null) {
		return await http.post<Delivery>("/deliveries/status", { deliveryId, observations });
	}

	async cancel(deliveryId: string, observations: string) {
		return await http.delete<Delivery>("/deliveries/status", { deliveryId, observations });
	}
}
