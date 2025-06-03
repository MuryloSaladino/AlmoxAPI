import { Component, inject } from "@angular/core";
import { AuthService } from "../../core/services/auth/auth.service";
import { EmployeeDashboardComponent } from "./employee/employee-dashboard.component";
import { AdminDashboardComponent } from "./admin/admin-dashboard.component";

@Component({
	selector: "dashboard",
	templateUrl: "./dashboard.component.html",
	standalone: true,
	imports: [
		AdminDashboardComponent,
		EmployeeDashboardComponent,
	],
})
export class DashboardComponent {

	readonly auth = inject(AuthService);
}
