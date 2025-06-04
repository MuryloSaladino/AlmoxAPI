import { Component, effect, Input, resource, signal } from "@angular/core";
import { Paginated } from "../../../core/http/interfaces";
import { ServerTableColumn } from "./server-table.types";
import { TablerIconComponent } from "angular-tabler-icons";

@Component({
	selector: "server-table",
	templateUrl: "./server-table.component.html",
	styleUrl: "./server-table.component.css",
	standalone: true,
	imports: [TablerIconComponent],
})
export class ServerTableComponent<T extends object> {

	@Input() loader!: (query?: string) => Promise<Paginated<T>>;
	@Input() columns: ServerTableColumn<T>[] = [];
	@Input() pageSize: number = 3;

	readonly page = signal(1);
	readonly data = resource({
		defaultValue: {
			page: this.page(),
			pageSize: this.pageSize,
			maxPage: 1,
			results: [],
		},
		loader: async () => await this.loader("?" + new URLSearchParams({
			page: this.page().toString(),
			pageSize: this.pageSize.toString(),
		}).toString()),
	});

	constructor() {
		effect(() => console.log(this.data.value().results))
	}

	async nextPage() {
		this.page.update(prev => Math.min(prev+1, this.data.value()!.maxPage));
		this.data.reload();
	}

	async prevPage() {
		this.page.update(prev => Math.max(prev-1, 1));
		this.data.reload();
	}
}
