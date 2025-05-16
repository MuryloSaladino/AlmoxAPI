import { UserContext } from "@/providers/user.context";
import { adminNavbarItems, navbarItems } from "@/components/app-layout/navbar-items";
import { AppShell, Button, Flex, rem, Stack } from "@mantine/core";
import { useContext, type ReactNode } from "react";
import { Link } from "react-router";


export function Navbar() {

    const { user } = useContext(UserContext);

    return (
        <AppShell.Navbar p="xs">
            <Flex direction="column" justify="space-between" h="100%">
                <Stack>
                    {navbarItems.map((item, i) => <NavbarItem key={i} {...item}/>)}
                </Stack>
                
                {user?.isAdmin &&
                    <Stack>
                        {adminNavbarItems.map((item, i) => <NavbarItem key={i} {...item}/>)}
                    </Stack>
                }
            </Flex>
        </AppShell.Navbar>
    )
}

export interface INavbarItemProps {
    title: string;
    icon?: ReactNode;
    color?: string;
    link: string;
}

function NavbarItem({ link, title, icon, color = "cyan" }: INavbarItemProps) {
    return (
        <Link to={link} style={{ display: "block", textDecoration: "none" }}>
            <Button
                fullWidth
                variant="subtle"
                leftSection={icon}
                children={title}
                color={color}
                fz={rem(16)}
                justify="flex-start"
            />
        </Link>
    )
}