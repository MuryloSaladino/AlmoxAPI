import { Pipe, PipeTransform } from "@angular/core";
import dayjs from "dayjs";

@Pipe({
    name: "formatDate",
	standalone: true,
})
export class FormatDatePipe implements PipeTransform {
    transform(date: any, format: string = "DD/MM/YYYY") {
        return dayjs(String(date)).format(format)
    }
}
