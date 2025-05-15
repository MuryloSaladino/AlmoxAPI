import { Logo } from "@/components/brand/logo";
import { AppShell, Burger, Group } from "@mantine/core";

export interface IHeaderProps {
    opened: boolean;
    onClick: () => void;
}

export function Header({
    opened,
    onClick,
}: IHeaderProps) {
    return (
        <AppShell.Header>
            <Group h="100%" px="md">
                <Burger
                    opened={opened}
                    onClick={onClick}
                    hiddenFrom="sm"
                    size="sm"
                />
                <Logo/>
            </Group>
        </AppShell.Header>
    )
}