import { Component, EventEmitter, inject, Input, Output } from "@angular/core";
import { CardComponent } from "../../../../shared/components/display/card/card.component";
import { AuthService } from "../../../../core/services/auth/auth.service";
import { OrderService } from "../../../../core/services/order/order.service";
import { BrlCurrencyPipe } from "../../../../shared/pipes/brl-currency.pipe";
import { ButtonComponent } from "../../../../shared/components/controls/button/button.component";
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from "@angular/forms";
import { InputComponent } from "../../../../shared/components/controls/input/input.component";
import { OrderCreation } from "../../../../core/types/entities/order.entity";

@Component({
	selector: "order-summary",
	templateUrl: "./order-summary.component.html",
	standalone: true,
	imports: [
		CardComponent,
		BrlCurrencyPipe,
		ButtonComponent,
		ReactiveFormsModule,
		InputComponent,
	],
})
export class OrderSummaryComponent {

	@Input() total!: number;
	@Input() orderedItems!: OrderCreation["orderedItems"];
	@Output() onSubmit = new EventEmitter<Event>();

	readonly auth = inject(AuthService);
	readonly orderService = inject(OrderService);
	readonly form: FormGroup;

	constructor(private fb: FormBuilder) {
		this.form = fb.group({
			priority: ['Unspecified', [Validators.required]],
			observations: [''],
		});
	}

	async submit() {
		await this.orderService.create({
			...this.form.value,
			orderedItems: this.orderedItems,
		});
		this.onSubmit.emit();
		this.form.reset();
	}
}
