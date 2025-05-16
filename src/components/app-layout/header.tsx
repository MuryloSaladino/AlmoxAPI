import { Logo } from "@/components/logo";
import { AppRoutes } from "@/config/constants/app-routes";
import { UserContext } from "@/providers/user.context";
import { AppShell, Avatar, Burger, Flex, Group, Menu } from "@mantine/core";
import { IconLogout } from "@tabler/icons-react";
import { useContext } from "react";
import { useNavigate } from "react-router";

export interface IHeaderProps {
    opened: boolean;
    onClick: () => void;
}

export function Header({
    opened,
    onClick,
}: IHeaderProps) {

    const { user, updateUser } = useContext(UserContext);
    const navigate = useNavigate();

    const logout = () => {
        updateUser(null);
        navigate(AppRoutes.LOGIN);
    }

    return (
        <AppShell.Header>
            <Flex>
                <Group h="100%" px="md">
                    <Burger
                        opened={opened}
                        onClick={onClick}
                        hiddenFrom="sm"
                        size="sm"
                    />
                    <Logo/>
                </Group>
                
                {user &&
                    <Menu>
                        <Menu.Target>
                            <Avatar color="initials" name={user.username}/>
                        </Menu.Target>

                        <Menu.Dropdown>
                            <Menu.Item leftSection={<IconLogout/>} onClick={logout}>
                                Logout
                            </Menu.Item>
                        </Menu.Dropdown>
                    </Menu>
                }
            </Flex>
        </AppShell.Header>
    )
}