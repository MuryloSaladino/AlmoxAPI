import { Component, inject, resource, signal } from "@angular/core";
import { UserService } from "../../../../../core/services/user/user.service";
import { TablerIconComponent } from "angular-tabler-icons";

@Component({
	selector: "user-table",
	templateUrl: "./user-table.component.html",
	standalone: true,
	imports: [TablerIconComponent],
})
export class UserTableComponent {

	readonly userService = inject(UserService);

	readonly page = signal(1);
	readonly users = resource({
		loader: async () => this.userService.getAll(this.page())
	})


	async nextPage() {
		this.page.update(prev => Math.min(prev+1, this.users.value()!.maxPage));
		this.users.reload();
	}
	async prevPage() {
		this.page.update(prev => Math.max(prev-1, 1));
		this.users.reload();
	}
}
