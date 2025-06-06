import { Component, computed, effect, inject, Input, resource, signal } from "@angular/core";
import { Paginated } from "../../../core/http/interfaces";
import { ServerTableColumn } from "./server-table.types";
import { TablerIconComponent } from "angular-tabler-icons";
import { FormatDatePipe } from "../../pipes/format-date.pipe";
import { BrlCurrencyPipe } from "../../pipes/brl-currency.pipe";
import { DomSanitizer, SafeHtml } from "@angular/platform-browser";

@Component({
	selector: "server-table",
	templateUrl: "./server-table.component.html",
	styleUrl: "./server-table.component.css",
	standalone: true,
	imports: [
		TablerIconComponent,
		FormatDatePipe,
		BrlCurrencyPipe,
	],
})
export class ServerTableComponent<T extends object> {

	@Input() loader!: (query?: string) => Promise<Paginated<T>>;
	@Input() columns: ServerTableColumn<T>[] = [];
	@Input() pageSize: number = 3;

	readonly sanitizer = inject(DomSanitizer);

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
	readonly emptyRows = computed(() => new Array(
		this.pageSize - this.data.value().results.length
	).fill(null))


	getCellHtml(column: ServerTableColumn<T>, row: T): SafeHtml {
		if (typeof column.renderCell === "function") {
			const rawHtml = column.renderCell(row);
			return this.sanitizer.bypassSecurityTrustHtml(rawHtml);
		}
		return "";
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
