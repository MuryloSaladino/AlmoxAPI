import { Injectable } from "@angular/core";
import { http } from "../../http";
import { AdminInsights } from "./insights.types";

@Injectable({ providedIn: "root" })
export class InsightsService {

	async admin() {
		return await http.get<AdminInsights>("/insights/admin");
	}
}
