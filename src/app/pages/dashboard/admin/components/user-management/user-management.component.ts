import { Component, inject, resource, signal } from "@angular/core";
import { InputComponent } from "../../../../../shared/components/controls/input/input.component";
import { ButtonComponent } from "../../../../../shared/components/controls/button/button.component";
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from "@angular/forms";
import { UserService } from "../../../../../core/services/user/user.service";
import { DepartmentService } from "../../../../../core/services/department/department.service";
import { CardComponent } from "../../../../../shared/components/display/card/card.component";

@Component({
	selector: "user-management",
	templateUrl: "./user-management.component.html",
 	imports: [
		InputComponent,
		ButtonComponent,
		ReactiveFormsModule,
		CardComponent,
	]
})
export class UserManagementComponent {

	readonly departmentService = inject(DepartmentService);
	readonly userService = inject(UserService);
	readonly loading = signal(false);
	readonly page = signal(1);
	readonly form: FormGroup;

	readonly departments = resource({
		loader: async () => await this.departmentService.getAll("?pageSize=100")
	})

	constructor(private fb: FormBuilder) {
		this.form = this.fb.group({
			username: ['', [Validators.required, Validators.minLength(3)]],
			email: ['', [Validators.required, Validators.email]],
			role: ['', [Validators.required]],
			departmentId: ['', [Validators.required]],
		});
	}

	async submit() {
		this.loading.set(true);
		await this.userService.create(this.form.value);
		this.loading.set(false);
		this.form.reset();
	}
}

