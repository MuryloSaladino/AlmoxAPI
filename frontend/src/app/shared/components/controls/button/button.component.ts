import { Component, EventEmitter, HostBinding, Input, Output } from "@angular/core";
import { TablerIconComponent } from "angular-tabler-icons";

@Component({
	selector: "app-button",
	templateUrl: "./button.component.html",
	styleUrl: "./button.component.css",
	standalone: true,
	imports: [TablerIconComponent]
})
export class ButtonComponent {
	@Input() type: "button" | "submit" | "reset" = "button";
	@Input() disabled = false;
	@Input() extraClass = "";

	@Input() variant: "primary" | "white" = "primary"
	@Input() rightIcon?: string;
	@Input() leftIcon?: string;
    @Output() onClick = new EventEmitter<MouseEvent>();
}
