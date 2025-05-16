import { UserContext } from "@/providers/user.context";
import { adminNavbarItems, navbarItems } from "@/components/app-layout/navbar-items";
import { AppShell, Button, Flex, rem, Stack } from "@mantine/core";
import { useContext, type ReactNode } from "react";
import { AppLink } from "../app-link";

export function Navbar() {

    const { user } = useContext(UserContext);

    return (
        <AppShell.Navbar p="xs">
            <Stack>
                {navbarItems.map((item, i) => <NavbarItem key={i} {...item}/>)}
                
                {user?.isAdmin &&
                    adminNavbarItems.map((item, i) => <NavbarItem key={i} {...item}/>)
                }
            </Stack>
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
        <AppLink to={link} type="block">
            <Button
                fullWidth
                variant="subtle"
                leftSection={icon}
                children={title}
                color={color}
                fz={rem(16)}
                justify="flex-start"
            />
        </AppLink>
    )
}