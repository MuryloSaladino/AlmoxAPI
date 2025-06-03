export const deliveryStatusOptions = [
    "Booked",
    "InTransit",
    "Received",
    "Canceled",
] as const;

export type DeliveryStatus = typeof deliveryStatusOptions[number];
