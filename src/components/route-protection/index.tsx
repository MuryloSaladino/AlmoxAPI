import { AppRoutes } from "@/config/constants/app-routes";
import { StorageKeys } from "@/config/constants/storage-keys";
import { UserContext } from "@/providers/user.context";
import { getUserById } from "@/services/almox/users";
import { jwtDecode } from "jwt-decode";
import { useContext, useState } from "react";
import { Navigate, Outlet } from "react-router";
import { PageLoading } from "../page-loading";

export function RouteProtection() {

    const { user, updateUser } = useContext(UserContext);
    const [loading, setLoading] = useState(false);
    const token = localStorage.getItem(StorageKeys.TOKEN);

    const setupUser = async (token: string) => {
        const { sub } = jwtDecode(token);
        const foundUser = await getUserById(sub!);
        updateUser(foundUser);
        setLoading(false)
    }

    if(!loading && !user && token) {
        setLoading(true);
        setupUser(token);
    }

    return loading
        ? <PageLoading/>
            : user
            ? <Outlet/>
        : <Navigate to={AppRoutes.LOGIN}/>
}