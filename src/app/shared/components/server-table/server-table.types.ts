export type FormatType = "none" | "date" | "currency";

export interface ServerTableColumn<T extends object> {
	label: string;
	path: keyof T;
	format?: FormatType;
}
