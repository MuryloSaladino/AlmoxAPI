import { Component, inject, resource } from "@angular/core";
import { AuthService } from "../../../core/services/auth/auth.service";
import { NavigationCardComponent } from "../../../shared/components/navigation-card/navigation-card.component";
import { CardComponent } from "../../../shared/components/card/card.component";
import { OrderService } from "../../../core/services/order/order.service";
import { OrderCardComponent } from "./components/order-card/order-card.component";

@Component({
	selector: "employee-dashboard",
	templateUrl: "employee-dashboard.component.html",
	styleUrl: "employee-dashboard.component.css",
	standalone: true,
	imports: [
		NavigationCardComponent,
		CardComponent,
		OrderCardComponent,
	],
})
export class EmployeeDashboardComponent {

	readonly auth = inject(AuthService);
	readonly orderService = inject(OrderService);

	readonly recentOrders = resource({
		loader: async () => await this.orderService.getAll("?pageSize=3")
	});
}
