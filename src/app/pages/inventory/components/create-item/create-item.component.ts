import { Component, computed, inject, resource, signal } from "@angular/core";
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from "@angular/forms";
import { InputComponent } from "../../../../shared/components/controls/input/input.component";
import { ButtonComponent } from "../../../../shared/components/controls/button/button.component";
import { CategoryService } from "../../../../core/services/category/category.service";
import { ItemService } from "../../../../core/services/item/item.service";
import { CardComponent } from "../../../../shared/components/display/card/card.component";

@Component({
	selector: "create-item",
	templateUrl: "./create-item.component.html",
 	imports: [
		InputComponent,
		ButtonComponent,
		ReactiveFormsModule,
		CardComponent,
	]
})
export class CreateItemComponent {

	readonly categoryService = inject(CategoryService);
	readonly itemService = inject(ItemService);
	readonly loading = signal(false);
	readonly page = signal(1);
	readonly form: FormGroup;
	readonly image = signal<File | null>(null);

	readonly categories = resource({
		loader: async () => await this.categoryService.getAll("?pageSize=100")
	})

	constructor(private fb: FormBuilder) {
		this.form = this.fb.group({
			name: ['', [Validators.required, Validators.minLength(3)]],
			categoryId: ['', [Validators.required]],
			price: ['', [Validators.required]],
			stock: ['', [Validators.required]],
			description: ['', [Validators.required]],
		});
	}

	async submit() {
		this.loading.set(true);

		const { price, stock, categoryId, ...values } = this.form.value;
		const { id } = await this.itemService.create({
			...values,
			price: Number(price),
			stock: Number(stock),
			categoryIds: [categoryId]
		});
		await this.itemService.updateImage(id, this.image()!)

		this.loading.set(false);
		this.form.reset();
	}

	onFileChange(event: Event) {
		const input = event.target as HTMLInputElement;

		if(input?.files?.length) {
			this.image.set(input.files[0])
		}
	}
}

