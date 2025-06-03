import { Injectable } from "@angular/core";
import { Paginated } from "../../http/interfaces";
import { http } from "../../http";
import { Department, DepartmentCreation } from "../../types/entities/department.entity";

@Injectable({ providedIn: "root" })
export class DepartmentService {

	async create(departmentCreation: DepartmentCreation) {
		return await http.post<Department>("/departments", departmentCreation);
	}

	async getAll() {
		return await http.get<Paginated<Department>>("/departments");
	}

	async delete(departmentId: string) {
		return await http.delete("/departments/" + departmentId);
	}
}
