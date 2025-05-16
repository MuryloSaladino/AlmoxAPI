import type { INavbarItemProps } from "@/components/app-layout/navbar";
import { AppRoutes } from "@/config/constants/app-routes";
import { IconBook, IconBrandTelegram, IconHome, IconMailbox, IconTruck } from "@tabler/icons-react";

export const navbarItems: INavbarItemProps[] = [
    {
        title: "Home",
        icon: <IconHome/>,
        link: AppRoutes.ROOT,
    },
    {
        title: "Catalog",
        icon: <IconBook/>,
        link: AppRoutes.CATALOG,
    },
    {
        title: "Requests",
        icon: <IconBrandTelegram/>,
        link: AppRoutes.CATALOG,
    },
];

export const adminNavbarItems: INavbarItemProps[] = [
    {
        title: "Deliveries",
        icon: <IconTruck/>,
        link: AppRoutes.DELIVERIES,
    },
]