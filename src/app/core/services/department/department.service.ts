import { Injectable } from "@angular/core";
import { Department, DepartmentCreation } from "../../interfaces/entities/department.entity";
import { Paginated } from "../../http/interfaces";
import { http } from "../../http";

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
