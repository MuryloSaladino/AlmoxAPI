import { App } from "@/App";
import { AppLayout } from "@/components/layout/app-layout";
import { AppRoutes } from "@/config/constants/app-routes";
import { Home } from "@/pages/home";
import { Login } from "@/pages/login";
import { createBrowserRouter } from "react-router";

export const router = createBrowserRouter([{
    Component: App,
    children: [
        {
            path: AppRoutes.LOGIN,
            Component: Login
        },
        {
            path: AppRoutes.ROOT,
            Component: AppLayout,
            children: [
                {
                    index: true,
                    Component: Home,
                },
            ]
        },
    ]
}])
