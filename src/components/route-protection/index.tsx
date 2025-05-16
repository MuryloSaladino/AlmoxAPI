import { AppRoutes } from "@/config/constants/app-routes";
import { UserContext } from "@/providers/user.context";
import { useContext } from "react";
import { Navigate, Outlet } from "react-router";

export function RouteProtection() {

    const { user } = useContext(UserContext);

    return user
        ? <Outlet/>
        : <Navigate to={AppRoutes.LOGIN}/>
}