export const orderPriorityOptions = [
    "Unspecified",
    "Low",
    "Medium",
    "High",
    "Urgent",
] as const;

export type OrderPriority = typeof orderPriorityOptions[number];
