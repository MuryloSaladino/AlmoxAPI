import { AppRoutes } from "@/config/constants/app-routes";
import { UserContext } from "@/providers/user.context";
import { Avatar, Button, Menu } from "@mantine/core";
import { IconLogout } from "@tabler/icons-react";
import { useContext } from "react";
import { useNavigate } from "react-router";

export function UserMenu() {

    const { user, updateUser } = useContext(UserContext);

    const navigate = useNavigate();

    const logout = () => {
        updateUser(null);
        navigate(AppRoutes.LOGIN);
    }

    return user && (
        <Menu>
            <Menu.Target>
                <Button variant="white" p={0}>
                    <Avatar color="initials" name={user.username} />
                </Button>
            </Menu.Target>

            <Menu.Dropdown>
                <Menu.Item leftSection={<IconLogout/>} onClick={logout}>
                    Logout
                </Menu.Item>
            </Menu.Dropdown>
        </Menu>
    )
}