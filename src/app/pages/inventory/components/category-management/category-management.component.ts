import { Component, inject, signal } from "@angular/core";
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from "@angular/forms";
import { CardComponent } from "../../../../shared/components/display/card/card.component";
import { InputComponent } from "../../../../shared/components/controls/input/input.component";
import { ButtonComponent } from "../../../../shared/components/controls/button/button.component";
import { ServerTableComponent } from "../../../../shared/components/display/server-table/server-table.component";
import { CategoryService } from "../../../../core/services/category/category.service";
import { ServerTableColumn } from "../../../../shared/components/display/server-table/server-table.types";
import { Category } from "../../../../core/types/entities/category.entity";

@Component({
	selector: "category-management",
	templateUrl: "./category-management.component.html",
 	imports: [
		CardComponent,
		InputComponent,
		ButtonComponent,
		ReactiveFormsModule,
		ServerTableComponent,
	]
})
export class CategoryManagementComponent {

	readonly categoryService = inject(CategoryService);
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
		await this.categoryService.create(this.form.value);
		this.loading.set(false);
		this.form.reset();
	}

	readonly columns: ServerTableColumn<Category>[] = [
		{ label: "Name", path: "name" },
		{ label: "Data de Criação", path: "createdAt", pipe: "date" },
	]
}
