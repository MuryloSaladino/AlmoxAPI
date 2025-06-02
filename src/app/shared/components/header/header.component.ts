import { Component, inject } from "@angular/core";
import { Router, RouterModule } from "@angular/router";
import { AppRoutes } from "../../../core/constants/app-routes";
import { AuthService } from "../../../core/services/auth/auth.service";
import { LogoComponent } from "../logo/logo.component";
import { ButtonComponent } from "../button/button.component";

interface NavItem {
	icon: string;
	title: string;
	link: string;
}

@Component({
	selector: "app-header",
	templateUrl: "./header.component.html",
	standalone: true,
	imports: [
		RouterModule,
		LogoComponent,
		ButtonComponent,
	]
})
export class HeaderComponent {

	readonly navItems: NavItem[] = [
		{
			link: AppRoutes.DASHBOARD,
			title: "Dashboard",
			icon: "grid_view",
		},
		{
			link: AppRoutes.ORDERS,
			title: "Orders",
			icon: "list",
		},
		{
			link: AppRoutes.CATALOG,
			title: "Catalog",
			icon: "full_coverage",
		},
		{
			link: AppRoutes.CART,
			title: "Cart",
			icon: "shopping_cart",
		},
	]
	readonly adminNavItems: NavItem[] = [
		...this.navItems,
		{
			link: AppRoutes.INVENTORY,
			title: "Inventory",
			icon: "inventory_2",
		},
		{
			link: AppRoutes.DELIVERIES,
			title: "Deliveries",
			icon: "local_shipping",
		},
	]

	protected readonly router = inject(Router);
	protected readonly auth = inject(AuthService);
	protected readonly items = !this.auth.userSubject.value
		? []
		: this.auth.userSubject.value.role === "Employee"
		? this.navItems
		: this.adminNavItems;

	isActiveRoute(route: string) {
		return this.router.url.includes(route);
	}
}
