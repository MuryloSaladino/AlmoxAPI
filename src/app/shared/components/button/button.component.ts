import { Component, Input } from '@angular/core';

@Component({
	selector: 'app-button',
	standalone: true,
	template: `
		<button
			[attr.type]="type"
			[disabled]="disabled"
			[class]="['button', extraClasses]"
		>
			<ng-content></ng-content>
		</button>
  	`,
	styleUrl: './button.component.css',
})
export class ButtonComponent {
	@Input() type: 'button' | 'submit' | 'reset' = 'button';
	@Input() disabled = false;
	@Input('class') extraClasses = '';
}
