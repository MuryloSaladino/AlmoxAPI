import { UserContext } from "@/providers/user.context";
import { useContext } from "react";
import { Outlet } from "react-router";

export function AuthenticationGuard() {

    const { user } = useContext(UserContext);

    return user?.isAdmin
        ? <Outlet/>
        : <></>
}