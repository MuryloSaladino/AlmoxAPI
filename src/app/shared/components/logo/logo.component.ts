import { Component } from "@angular/core";
import { IconComponent } from "../icon/icon.component";

@Component({
	selector: "almox-logo",
	templateUrl: "./logo.component.html",
	standalone: true,
	imports: [IconComponent]
})
export class LogoComponent {}
