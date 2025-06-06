import { Component, inject, resource } from "@angular/core";
import { CardComponent } from "../../../../shared/components/card/card.component";
import { InsightsService } from "../../../../core/services/insights/insights.service";

@Component({
	selector: "insights",
	templateUrl: "./insights.component.html",
	standalone: true,
 	imports: [CardComponent],
})
export class InsightsComponent {
	readonly insightsService = inject(InsightsService);

	readonly insights = resource({
		loader: async () => await this.insightsService.inventory(),
	})
}
