export const userRoleOptions = [
	"Admin",
	"Staff",
	"Employee"
] as const;

export type UserRole = typeof userRoleOptions[number];
