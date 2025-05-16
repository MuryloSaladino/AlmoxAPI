export const AppRoutes = {
    ROOT: "/",
    LOGIN: "/login",

    CATALOG: "/catalog",
    CART: "/cart",
    
    DEPARTMENTS: "/departments",
    DEPARTMENT_DETAILS: (id: string = ":id") => `/departments/${id}`,

    REQUESTS: "/requests",
    REQUEST_DETAILS: (id: string = ":id") => `/requests/${id}`,

    DELIVERIES: "/deliveries",
    DELIVERY_DETAILS: (id: string = ":id") => `/deliveries/${id}`,
} as const;