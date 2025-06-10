import { Component, computed, effect, inject, signal } from "@angular/core";
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
			icon: "layout-dashboard",
		},
		{
			link: AppRoutes.ORDERS,
			title: "Orders",
			icon: "list",
		},
		{
			link: AppRoutes.CATALOG,
			title: "Catalog",
			icon: "library",
		},
		{
			link: AppRoutes.CART,
			title: "Cart",
			icon: "shopping-cart",
		},
	]
	readonly adminNavItems: NavItem[] = [
		...this.navItems,
		{
			link: AppRoutes.INVENTORY,
			title: "Inventory",
			icon: "box",
		},
		{
			link: AppRoutes.DELIVERIES,
			title: "Deliveries",
			icon: "truck",
		},
	]

	readonly auth = inject(AuthService);
	readonly router = inject(Router);
	readonly menuOpen = signal(false);
	readonly items = computed(
		() => !this.auth.user()
			? []
			: this.auth.user()!.role === "Employee"
			? this.navItems
			: this.adminNavItems
	)

	toggle(event: MouseEvent) {
		event.stopPropagation();
		this.menuOpen.update(prev => !prev);
	}

	logout() {
		this.auth.logout();
		this.router.navigate([AppRoutes.LOGIN]);
	}
}
