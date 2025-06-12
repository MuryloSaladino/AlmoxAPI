import { Component, inject, resource, signal } from "@angular/core";
import { CardComponent } from "../../shared/components/display/card/card.component";
import { OrderService } from "../../core/services/order/order.service";
import { TablerIconComponent } from "angular-tabler-icons";
import { OrderCardComponent } from "./components/order-card/order-card.component";

@Component({
	selector: "orders",
	templateUrl: "./orders.component.html",
	standalone: true,
	imports: [
		CardComponent,
		TablerIconComponent,
		OrderCardComponent,
	],
})
export class OrdersComponent {

	readonly orderService = inject(OrderService);
	readonly status = signal<string>("");
	readonly page = signal<number>(1);

	readonly orders = resource({
		loader: async () => await this.orderService.getAll(`?pageSize=10&page=${this.page()}&status=${this.status()}`),
		defaultValue: {
			maxPage: 1,
			page: this.page(),
			pageSize: 10,
			results: [],
		}
	})

	updateStatus(event: Event) {
		const select = event.target as HTMLSelectElement;
		this.status.set(select.value);
		this.orders.reload();
	}

	readonly refresh = () => this.orders.reload();

	async nextPage() {
		this.page.update(prev => Math.min(prev+1, this.orders.value()!.maxPage));
		this.orders.reload();
	}

	async prevPage() {
		this.page.update(prev => Math.max(prev-1, 1));
		this.orders.reload();
	}
}
