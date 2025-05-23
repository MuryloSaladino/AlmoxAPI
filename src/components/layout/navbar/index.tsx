import { UserContext } from "@/providers/user.context";
import { AppShell, Stack } from "@mantine/core";
import { useContext } from "react";
import { adminNavbarItems, navbarItems } from "./config";
import { NavbarItem } from "./item";

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

