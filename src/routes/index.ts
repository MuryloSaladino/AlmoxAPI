import { App } from "@/App";
import { AppLayout } from "@/components/app-layout";
import { RouteProtection } from "@/components/route-protection";
import { AppRoutes } from "@/config/constants/app-routes";
import { Home } from "@/pages/home";
import { Login } from "@/pages/login";
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
                ]
            }]
        },
    ]
}])
