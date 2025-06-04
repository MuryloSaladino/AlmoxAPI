import { Component, inject, resource } from "@angular/core";
import { InsightsService } from "../../../../../core/services/insights/insights.service";
import { CardComponent } from "../../../../../shared/components/card/card.component";

@Component({
	selector: "insights",
	templateUrl: "./insights.component.html",
	standalone: true,
 	imports: [CardComponent],
})
export class InsightsComponent {
	readonly insightsService = inject(InsightsService);

	readonly insights = resource({
		loader: async () => await this.insightsService.admin(),
	})
}
