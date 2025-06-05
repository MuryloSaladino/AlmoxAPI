import { Component, Input } from "@angular/core";
import { CardComponent } from "../card/card.component";
import { RouterModule } from "@angular/router";
import { TablerIconComponent } from "angular-tabler-icons";
import { ButtonComponent } from "../button/button.component";

@Component({
	selector: "navigation-card",
	templateUrl: "./navigation-card.component.html",
	standalone: true,
	imports: [
		CardComponent,
		RouterModule,
		TablerIconComponent,
		ButtonComponent
	],
})
export class NavigationCardComponent {
	@Input() icon!: string;
	@Input() iconColor!: string;
	@Input() title!: string;
	@Input() description!: string;
	@Input() link: string = "";
	@Input() linkText!: string;
}
