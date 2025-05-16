import { Logo } from "@/components/logo";
import { AppRoutes } from "@/config/constants/app-routes";
import { UserContext } from "@/providers/user.context";
import { AppShell, Avatar, Burger, Button, Flex, Group, Menu } from "@mantine/core";
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
        <AppShell.Header px="md">
            <Flex h="100%" align="center" justify="space-between">
                <Group h="100%">
                    <Burger
                        opened={opened}
                        onClick={onClick}
                        hiddenFrom="sm"
                        size="sm"
                    />
                    <Logo redirectToHome/>
                </Group>
                
                {user &&
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
                }
            </Flex>
        </AppShell.Header>
    )
}