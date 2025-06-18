export type Pipe = "none" | "date" | "currency";

export interface ServerTableColumn<T extends object> {
	label: string;
	path?: keyof T;
	pipe?: Pipe;
	renderCell?: (row: T) => string;
}
