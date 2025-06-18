import { Component, inject, signal } from "@angular/core";
import { InputComponent } from "../../../../../shared/components/controls/input/input.component";
import { ButtonComponent } from "../../../../../shared/components/controls/button/button.component";
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from "@angular/forms";
import { DepartmentService } from "../../../../../core/services/department/department.service";
import { ServerTableComponent } from "../../../../../shared/components/display/server-table/server-table.component";
import { ServerTableColumn } from "../../../../../shared/components/display/server-table/server-table.types";
import { Department } from "../../../../../core/types/entities/department.entity";
import { CardComponent } from "../../../../../shared/components/display/card/card.component";

@Component({
	selector: "department-management",
	templateUrl: "./department-management.component.html",
 	imports: [
		CardComponent,
		InputComponent,
		ButtonComponent,
		ReactiveFormsModule,
		ServerTableComponent,
	]
})
export class DepartmentManagementComponent {

	readonly departmentService = inject(DepartmentService);
	readonly loading = signal(false);
	readonly page = signal(1);
	readonly form: FormGroup;

	constructor(private fb: FormBuilder) {
		this.form = this.fb.group({
			name: ['', [Validators.required, Validators.minLength(3)]],
		});
	}

	async submit() {
		this.loading.set(true);
		await this.departmentService.create(this.form.value);
		this.loading.set(false);
		this.form.reset();
	}

	readonly columns: ServerTableColumn<Department>[] = [
		{ label: "Name", path: "name" },
		{ label: "Users", path: "userCount" },
	]
}
