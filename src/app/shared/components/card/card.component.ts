import { Component, HostBinding, Input } from "@angular/core";
import { TablerIconComponent } from "angular-tabler-icons";

@Component({
	selector: "card",
	templateUrl: "./card.component.html",
	standalone: true,
	imports: [TablerIconComponent]
})
export class CardComponent {
	@Input("class") extraClass = "";
	@Input() noHover: boolean = false;

	@Input() title?: string;
	@Input() titleClass: string = "";

	@Input() helperText?: string;
	@Input() helperTextClass: string = "";

	@Input() icon?: string;
	@Input() iconClass: string = "";

	@HostBinding("class")
	get hostClass(): string {
		return "relative shadow-sm px-4 py-6 rounded-sm " + this.extraClass;
	}
}
