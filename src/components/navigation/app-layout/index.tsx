import { AppShell } from "@mantine/core";
import { useDisclosure } from "@mantine/hooks";
import { Outlet, useNavigation } from "react-router";
import { Header } from "./header";
import { Navbar } from "./navbar";
import { PageLoading } from "@/components/feedback/page-loading";

export function AppLayout() {

    const [opened, { toggle }] = useDisclosure();
    const navigation = useNavigation();
    const isNavigating = Boolean(navigation.location);

    return (
        <AppShell
            padding="md"
            header={{ height: 60 }}
            navbar={{ width: 200, breakpoint: 'sm', collapsed: { mobile: !opened } }}
        >
            <Header opened={opened} onClick={toggle} />

            <Navbar/>

            <AppShell.Main>
                {
                    isNavigating
                    ? <PageLoading/>
                    : <Outlet/>
                }
            </AppShell.Main>
        </AppShell>
    )
}