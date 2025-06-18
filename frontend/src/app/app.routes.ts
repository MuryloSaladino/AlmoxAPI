import { Routes } from '@angular/router';
import { AppRoutes } from './core/constants/app-routes';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { LoginComponent } from './pages/login/login.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { PageLayoutComponent } from './shared/components/layout/page-layout/page-layout.component';
import { authGuard } from './core/guards/auth.guard';
import { InventoryComponent } from './pages/inventory/inventory.component';
import { DeliveriesComponent } from './pages/deliveries/deliveries.component';
import { CartComponent } from './pages/cart/cart.component';
import { CatalogComponent } from './pages/catalog/catalog.component';
import { OrdersComponent } from './pages/orders/orders.component';

export const routes: Routes = [
	{
		path: "",
		redirectTo: AppRoutes.LOGIN,
		pathMatch: 'full',
	},
	{
		path: AppRoutes.NOT_FOUND,
		component: NotFoundComponent,
	},
	{
		path: AppRoutes.LOGIN,
		component: LoginComponent
	},
	{
		path: "",
		component: PageLayoutComponent,
		canActivate: [authGuard],
		children: [
			{
				path: AppRoutes.DASHBOARD,
				component: DashboardComponent,
			},
			{
				path: AppRoutes.INVENTORY,
				component: InventoryComponent,
			},
			{
				path: AppRoutes.DELIVERIES,
				component: DeliveriesComponent,
			},
			{
				path: AppRoutes.CART,
				component: CartComponent,
			},
			{
				path: AppRoutes.CATALOG,
				component: CatalogComponent,
			},
			{
				path: AppRoutes.ORDERS,
				component: OrdersComponent,
			},
		]
	},
	{
		path: "**",
		redirectTo: AppRoutes.NOT_FOUND,
	},
];
