import { App } from "@/App";
import { AppLayout } from "@/components/app-layout";
import { RouteProtection } from "@/components/route-protection";
import { AppRoutes } from "@/config/constants/app-routes";
import { Cart } from "@/pages/cart";
import { Catalog } from "@/pages/catalog";
import { Deliveries } from "@/pages/deliveries";
import { DeliveryDetails } from "@/pages/delivery-details";
import { DepartmentDetails } from "@/pages/department-details";
import { Departments } from "@/pages/departments";
import { Home } from "@/pages/home";
import { Login } from "@/pages/login";
import { RequestDetails } from "@/pages/request-details";
import { Requests } from "@/pages/requests";
import { createBrowserRouter } from "react-router";

export const router = createBrowserRouter([{
    Component: App,
    children: [
        {
            path: AppRoutes.LOGIN,
            Component: Login,
        },
        {
            Component: RouteProtection,
            children: [{
                Component: AppLayout,
                children: [
                    {
                        path: AppRoutes.ROOT,
                        Component: Home,
                    },
                    {
                        path: AppRoutes.CART,
                        Component: Cart,
                    },
                    {
                        path: AppRoutes.CATALOG,
                        Component: Catalog,
                    },
                    {
                        path: AppRoutes.DEPARTMENTS,
                        Component: Departments,
                    },
                    {
                        path: AppRoutes.DEPARTMENT_DETAILS(),
                        Component: DepartmentDetails,
                    },
                    {
                        path: AppRoutes.DELIVERIES,
                        Component: Deliveries,
                    },
                    {
                        path: AppRoutes.DELIVERY_DETAILS(),
                        Component: DeliveryDetails,
                    },
                    {
                        path: AppRoutes.REQUESTS,
                        Component: Requests,
                    },
                    {
                        path: AppRoutes.REQUEST_DETAILS(),
                        Component: RequestDetails,
                    }
                ]
            }]
        },
    ]
}])
