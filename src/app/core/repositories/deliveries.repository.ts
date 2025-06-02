import { inject, Injectable } from "@angular/core";
import { ApiService } from "../services/api/api.service";
import { Paginated } from "../services/api/api.interfaces";
import { Delivery, DeliveryCreation } from "../entities/delivery.entity";

@Injectable({ providedIn: "root" })
export class DeliveriesRepository {

	private readonly api = inject(ApiService);

	create(deliveryCreation: DeliveryCreation) {
		return this.api.post<Delivery>("/deliveries", deliveryCreation);
	}

	getAll() {
		return this.api.get<Paginated<Delivery>>("/deliveries");
	}

	advanceStatus(deliveryId: string, observations: string | null) {
		return this.api.post<Delivery>("/deliveries/status", { deliveryId, observations });
	}

	cancel(deliveryId: string, observations: string) {
		return this.api.delete<Delivery>("/deliveries/status", { deliveryId, observations });
	}
}
