import { inject, Injectable } from "@angular/core";
import { ApiService } from "../services/api/api.service";
import { Department, DepartmentCreation } from "../entities/department.entity";
import { Paginated } from "../services/api/api.interfaces";

@Injectable({ providedIn: "root" })
export class DepartmentsRepository {

	private readonly api = inject(ApiService);

	create(departmentCreation: DepartmentCreation) {
		return this.api.post<Department>("/departments", departmentCreation);
	}

	getAll() {
		return this.api.get<Paginated<Department>>("/departments");
	}

	delete(departmentId: string) {
		return this.api.delete("/departments/" + departmentId);
	}
}
