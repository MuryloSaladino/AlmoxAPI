import { Component } from "@angular/core";
import { RouterModule } from "@angular/router";
import { HeaderComponent } from "../header/header.component";

@Component({
	selector: "page-layout",
	templateUrl: "./page-layout.component.html",
	styleUrl: "./page-layout.component.css",
	standalone: true,
	imports: [RouterModule, HeaderComponent],
})
export class PageLayoutComponent {}
