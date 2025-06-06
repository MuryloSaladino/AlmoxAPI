import { Component, inject } from "@angular/core";
import { InsightsComponent } from "./components/insights/insights.component";
import { CategoryManagementComponent } from "./components/category-management/category-management.component";
import { CreateItemComponent } from "./components/create-item/create-item.component";
import { CardComponent } from "../../shared/components/card/card.component";
import { ItemService } from "../../core/services/item/item.service";
import { ServerTableComponent } from "../../shared/components/server-table/server-table.component";
import { ServerTableColumn } from "../../shared/components/server-table/server-table.types";
import { Item } from "../../core/types/entities/items.types";

@Component({
	selector: "inventory",
	templateUrl: "./inventory.component.html",
	standalone: true,
	imports: [
    InsightsComponent,
    CreateItemComponent,
    CategoryManagementComponent,
    CardComponent,
    ServerTableComponent
],
})
export class InventoryComponent {

	readonly itemService = inject(ItemService);

	readonly columns: ServerTableColumn<Item>[] = [
		{ label: "Image", renderCell: (i) => `<img class="h-12 w-12 object-cover" src="${i.imageUrl}"/>` },
		{ label: "Name", path: "name" },
		{ label: "Category", renderCell: (i) => i.categories[0].name },
		{ label: "Price", path: "price", pipe: "currency" },
		{ label: "Stock", path: "stock" },
		{ label: "Description", path: "description" },
	]
}
