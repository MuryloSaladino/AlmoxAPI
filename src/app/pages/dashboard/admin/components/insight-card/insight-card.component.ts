import { Component, Input } from "@angular/core";
import { TablerIconComponent } from "angular-tabler-icons";

@Component({
	selector: "insight-card",
	templateUrl: "./insight-card.component.html",
	standalone: true,
 	imports: [TablerIconComponent],
})
export class InsightCardComponent {
	@Input() title!: string;
	@Input() icon!: string;
	@Input() value!: string | number;
}
