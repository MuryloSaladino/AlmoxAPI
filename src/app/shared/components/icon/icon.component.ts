import { Component, Input, HostBinding } from "@angular/core";

@Component({
	selector: "app-icon",
	template: "{{ name }}",
	standalone: true,
})
export class IconComponent {
	@Input() name!: string;
	@Input("class") extraClasses: string = "";

	@HostBinding("class")
	get hostClasses(): string {
		return `material-symbols-rounded ${this.extraClasses}`;
	}
}
