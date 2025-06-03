import { Component } from "@angular/core";
import { RouterModule } from "@angular/router";
import { AppRoutes } from "../../core/constants/app-routes";
import { ButtonComponent } from "../../shared/components/button/button.component";

@Component({
	selector: "not-found",
	templateUrl: "./not-found.component.html",
	standalone: true,
	imports: [RouterModule, ButtonComponent],
})
export class NotFoundComponent {
	readonly home = ["/", AppRoutes.DASHBOARD];
}
