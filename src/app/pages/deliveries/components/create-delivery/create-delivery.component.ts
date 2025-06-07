import { Component, inject, Input, resource, signal } from "@angular/core";
import { CardComponent } from "../../../../shared/components/card/card.component";
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from "@angular/forms";
import { InputComponent } from "../../../../shared/components/input/input.component";
import { ButtonComponent } from "../../../../shared/components/button/button.component";
import { DeliveryService } from "../../../../core/services/delivery/delivery.service";
import { DeliveryItem } from "../../../../core/types/entities/delivery.entity";
import { ItemService } from "../../../../core/services/item/item.service";
import { BrlCurrencyPipe } from "../../../../shared/pipes/brl-currency.pipe";
import dayjs from "dayjs";
import customParseFormat from 'dayjs/plugin/customParseFormat'

@Component({
	selector: "create-delivery",
	templateUrl: "./create-delivery.component.html",
	standalone: true,
	imports: [
		CardComponent,
		InputComponent,
		ReactiveFormsModule,
		ButtonComponent,
		BrlCurrencyPipe,
	]
})
export class CreateDeliveryComponent {

	@Input() refresh!: () => void
	readonly deliveryService = inject(DeliveryService);

	readonly itemService = inject(ItemService);
	readonly itemOptions = resource({
		loader: async () => await this.itemService.getAll("?pageSize=100")
	})

	readonly form: FormGroup;
	readonly deliveryItems = signal<Omit<DeliveryItem, "deliveryId">[]>([]);

	readonly addItemForm: FormGroup;

	constructor(private fb: FormBuilder) {
		this.form = this.fb.group({
			supplier: ['', [Validators.required]],
			expectedDate: ['', [Validators.required]],
			observations: ['', [Validators.required]],
		});
		this.addItemForm = this.fb.group({
			itemId: ['', Validators.required],
			quantity: ['', [Validators.required]],
			supplierPrice: ['', [Validators.required]],
		});
	}

	submitItem() {
		const { itemId } = this.addItemForm.value
		const item = this.itemOptions.value()?.results.find(x => x.id == itemId)!
		this.deliveryItems.update(prev => [...prev, {
			item, ...this.addItemForm.value
		}])
		this.addItemForm.reset();
	}

	async submit() {
		const items = this.deliveryItems().map(({ item, ...rest }) => rest);
		const { expectedDate, ...values } = this.form.value;
		dayjs.extend(customParseFormat);
		await this.deliveryService.create({
			...values, items,
			expectedDate: dayjs(expectedDate, "DD/MM/YYYY").toISOString()
		});
		this.refresh();
	}
}

