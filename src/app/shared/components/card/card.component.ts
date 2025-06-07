import { Component, HostBinding, Input } from "@angular/core";
import { TablerIconComponent } from "angular-tabler-icons";

@Component({
	selector: "card",
	templateUrl: "./card.component.html",
	standalone: true,
	imports: [TablerIconComponent]
})
export class CardComponent {
	@Input() title?: string;
	@Input() helperText?: string;
	@Input() icon?: string;
	@Input() cover: string | null = null;

	@HostBinding("class")
	get hostClass(): string {
		return "";
	}
}
