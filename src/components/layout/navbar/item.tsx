import { AppLink } from "@/components/utils/app-link";
import { Button, rem } from "@mantine/core";
import type { ComponentType } from "react";

export interface INavbarItemProps {
    title: string;
    link: string;
    Icon: ComponentType;
}

export function NavbarItem({ link, title, Icon }: INavbarItemProps) {
    return (
        <AppLink to={link} type="block">
            <Button
                fullWidth
                variant="subtle"
                leftSection={<Icon/>}
                children={title}
                color={"cyan"}
                fz={rem(16)}
                justify="flex-start"
            />
        </AppLink>
    )
}