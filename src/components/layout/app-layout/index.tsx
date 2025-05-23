import { AppShell } from "@mantine/core";
import { useDisclosure } from "@mantine/hooks";
import { Outlet } from "react-router";
import { Header } from "../header";
import { Navbar } from "../navbar";

export function AppLayout() {

    const [opened, { toggle }] = useDisclosure();

    return (
        <AppShell
            padding="md"
            header={{ height: 60 }}
            navbar={{ width: 200, breakpoint: 'sm', collapsed: { mobile: !opened } }}
        >
            <Header opened={opened} onClick={toggle} />

            <Navbar/>

            <AppShell.Main>
                <Outlet/>
            </AppShell.Main>
        </AppShell>
    )
}