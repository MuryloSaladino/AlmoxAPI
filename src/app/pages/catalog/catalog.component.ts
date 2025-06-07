import { Component, inject, resource, signal } from "@angular/core";
import { CardComponent } from "../../shared/components/card/card.component";
import { ItemService } from "../../core/services/item/item.service";
import { CategoryService } from "../../core/services/category/category.service";
import { InputComponent } from "../../shared/components/input/input.component";
import { FormBuilder, FormGroup, ReactiveFormsModule } from "@angular/forms";
import { ItemCardComponent } from "./components/item-card/item-card.component";

@Component({
	selector: "orders",
	templateUrl: "./catalog.component.html",
	standalone: true,
	imports: [
		CardComponent,
		InputComponent,
		ReactiveFormsModule,
		ItemCardComponent,
	],
})
export class CatalogComponent {

	readonly itemService = inject(ItemService);
	readonly categoryService = inject(CategoryService);
	readonly filters = signal<string>("");
	readonly form: FormGroup;

	readonly categories = resource({
		loader: async () => await this.categoryService.getAll("?pageSize=100")
	})
	readonly items = resource({
		loader: async () => await this.itemService.getAll(this.filters())
	})

	constructor(private fb: FormBuilder) {
		this.form = fb.group({
			name: [''],
			categoryName: [''],
		});
	}

	updateItems() {
		this.filters.set(`?${new URLSearchParams(this.form.value)}`)
		this.items.reload();
	}
}
