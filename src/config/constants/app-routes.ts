export const AppRoutes = {
    ROOT: "/",
    LOGIN: "/login",

    CATALOG: "/catalog",
    CART: "/cart",
    
    DEPARTMENTS: "/departments",

    ORDERS: "/orders",
    ORDER_DETAILS: (id: string = ":id") => `/orders/${id}`,

    DELIVERIES: "/deliveries",
    DELIVERY_DETAILS: (id: string = ":id") => `/deliveries/${id}`,
} as const;