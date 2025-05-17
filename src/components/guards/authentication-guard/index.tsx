import { AppRoutes } from "@/config/constants/app-routes";
import { StorageKeys } from "@/config/constants/storage-keys";
import { UserContext } from "@/providers/user.context";
import { jwtDecode } from "jwt-decode";
import { useContext, useState } from "react";
import { Navigate, Outlet, useNavigate } from "react-router";
import { PageLoading } from "../../feedback/page-loading";
import { UsersService } from "@/services/almox/users.service";

export function AuthenticationGuard() {

    const { user, updateUser } = useContext(UserContext);
    const [loading, setLoading] = useState(false);
    const token = localStorage.getItem(StorageKeys.TOKEN);
    const navigate = useNavigate();

    const setupUser = async (token: string) => {
        try {
            const { sub } = jwtDecode(token);
            const foundUser = await UsersService.getById(sub!);
            updateUser(foundUser);
            setLoading(false)
        } catch (error) {
            localStorage.removeItem(StorageKeys.TOKEN);
            navigate(AppRoutes.LOGIN);
        }
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