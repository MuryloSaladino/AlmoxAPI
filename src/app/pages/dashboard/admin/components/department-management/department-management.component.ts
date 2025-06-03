import { Component, inject, resource, signal } from "@angular/core";
import { InputComponent } from "../../../../../shared/components/input/input.component";
import { ButtonComponent } from "../../../../../shared/components/button/button.component";
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from "@angular/forms";
import { DepartmentService } from "../../../../../core/services/department/department.service";
import { TablerIconComponent } from "angular-tabler-icons";

@Component({
	selector: "department-management",
	templateUrl: "./department-management.component.html",
 	imports: [
		InputComponent,
		ButtonComponent,
		TablerIconComponent,
		ReactiveFormsModule,
	]
})
export class DepartmentManagement {

	readonly departmentService = inject(DepartmentService);
	readonly loading = signal(false);
	readonly page = signal(1);
	readonly form: FormGroup;

	readonly departments = resource({
		loader: async () => await this.departmentService.getAll(this.page()),
	})

	constructor(private fb: FormBuilder) {
		this.form = this.fb.group({
			name: ['', [Validators.required, Validators.minLength(3)]],
		});
	}

	async submit() {
		this.loading.set(true);
		await this.departmentService.create(this.form.value);
		this.departments.reload();
		this.loading.set(false);
	}

	async nextPage() {
		this.page.update(prev => Math.min(prev+1, this.departments.value()!.maxPage));
		this.departments.reload();
	}
	async prevPage() {
		this.page.update(prev => Math.max(prev-1, 1));
		this.departments.reload();
	}
}
