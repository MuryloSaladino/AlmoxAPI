import { Component, effect, inject, resource } from "@angular/core";
import { DepartmentService } from "../../../core/services/department/department.service";
import { UserService } from "../../../core/services/user/user.service";
import { InsightsComponent } from "./components/insights/insights.component";
import { InsightsService } from "../../../core/services/insights/insights.service";
import { DepartmentManagement } from "./components/department-management/department-management.component";
import { UserManagementComponent } from "./components/user-management/user-management.component";
import { UserTableComponent } from "./components/user-table/user-table.component";

@Component({
	selector: "admin-dashboard",
	templateUrl: "admin-dashboard.component.html",
	styleUrl: "admin-dashboard.component.css",
	standalone: true,
	imports: [
		InsightsComponent,
		DepartmentManagement,
		UserManagementComponent,
		UserTableComponent,
	],
})
export class AdminDashboardComponent {

	readonly userService = inject(UserService);

	readonly users = resource({
		loader: async () => await this.userService.getAll(),
	})
}
