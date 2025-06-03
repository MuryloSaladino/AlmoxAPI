import { Component, inject, resource } from "@angular/core";
import { TablerIconComponent } from "angular-tabler-icons";
import { InsightsService } from "../../../../../core/services/insights/insights.service";

@Component({
	selector: "insights",
	templateUrl: "./insights.component.html",
	standalone: true,
 	imports: [TablerIconComponent],
})
export class InsightsComponent {
	readonly insightsService = inject(InsightsService);

	readonly insights = resource({
		loader: async () => await this.insightsService.admin(),
	})
}
