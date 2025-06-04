export interface ServerTableColumn<T extends object> {
	label: string;
	path: keyof T;
}
