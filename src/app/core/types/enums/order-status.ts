export const orderStatusOptions = [
    "Requested",
    "Accepted",
    "Ready",
    "Completed",
    "Canceled",
] as const;

export type OrderStatus = typeof orderStatusOptions[number];
