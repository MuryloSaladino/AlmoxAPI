import { Component, EventEmitter, Input, Output } from "@angular/core";
import { IconComponent } from "../icon/icon.component";

@Component({
	selector: "app-button",
	templateUrl: "./button.component.html",
	styleUrl: "./button.component.css",
	standalone: true,
	imports: [IconComponent]
})
export class ButtonComponent {
	@Input() type: "button" | "submit" | "reset" = "button";
	@Input() disabled = false;
	@Input("class") extraClasses = "";

	@Input() variant: "primary" | "white" = "primary"
	@Input() rightIcon?: string;
	@Input() leftIcon?: string;
    @Output() click = new EventEmitter<Event>();
}
