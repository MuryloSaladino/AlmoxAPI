import { Component, inject } from "@angular/core";
import { UserService } from "../../../core/services/user/user.service";
import { InsightsComponent } from "./components/insights/insights.component";
import { DepartmentManagementComponent } from "./components/department-management/department-management.component";
import { UserManagementComponent } from "./components/user-management/user-management.component";
import { ServerTableColumn } from "../../../shared/components/server-table/server-table.types";
import { User } from "../../../core/types/entities/user.entity";
import { CardComponent } from "../../../shared/components/card/card.component";
import { ServerTableComponent } from "../../../shared/components/server-table/server-table.component";
import { NavigationCardComponent } from "../../../shared/components/navigation-card/navigation-card.component";

@Component({
	selector: "admin-dashboard",
	templateUrl: "./admin-dashboard.component.html",
	standalone: true,
	imports: [
		InsightsComponent,
		DepartmentManagementComponent,
		UserManagementComponent,
		CardComponent,
		ServerTableComponent,
		NavigationCardComponent
	],
})
export class AdminDashboardComponent {

	readonly userService = inject(UserService);

	readonly userColumns: ServerTableColumn<User>[] = [
		{ label: "Username", path: "username" },
		{ label: "Department", path: "departmentName" },
		{ label: "Email", path: "email" },
		{ label: "Role", path: "role" },
	]
}
