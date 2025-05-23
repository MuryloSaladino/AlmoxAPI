import { Group, Title, type GroupProps } from "@mantine/core";
import { IconStack3 } from "@tabler/icons-react";
import { AppRoutes } from "@/config/constants/app-routes";
import { AppLink } from "@/components/utils/app-link";
import { useMediaQuery } from "@mantine/hooks";

export interface ILogoProps extends GroupProps {
    size?: "sm" | "md" | "lg";
    redirectToHome?: boolean;
}

export function Logo({ 
    redirectToHome, 
    size = "md",
    ...groupProps 
}: ILogoProps) {

    const sizeOptions = { "sm": 24, "md": 32, "lg": 48 };
    const matches = useMediaQuery('(min-width: 500px)');

    const logo = (
        <Group color="cyan" gap={4} {...groupProps}>
            <IconStack3 size={sizeOptions[size]} color="#15aabf"/>
            {matches &&
                <Title 
                    c="cyan"
                    order={1} 
                    ta="center" 
                    fz={sizeOptions[size]}
                >Almox</Title>
            }
        </Group>
    )

    return redirectToHome
        ? <AppLink to={AppRoutes.ROOT}>{ logo }</AppLink>
        : logo;
}