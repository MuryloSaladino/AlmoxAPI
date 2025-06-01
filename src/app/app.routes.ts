import { Routes } from '@angular/router';
import { AppRoutes } from './core/constants/app-routes';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { LoginComponent } from './pages/login/login.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { PageLayoutComponent } from './shared/components/page-layout/page-layout.component';
import { authGuard } from './core/guards/auth.guard';

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
		]
	},
	{
		path: "**",
		redirectTo: AppRoutes.NOT_FOUND,
	},
];
