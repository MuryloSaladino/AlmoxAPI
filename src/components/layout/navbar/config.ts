import { AppRoutes } from "@/config/constants/app-routes";
import { IconBook, IconBrandTelegram, IconBuilding, IconHome, IconTruck } from "@tabler/icons-react";
import type { INavbarItemProps } from "./item";

export const navbarItems: INavbarItemProps[] = [
    {
        title: "Home",
        link: AppRoutes.ROOT,
        Icon: IconHome,
    },
    {
        title: "Catalog",
        link: AppRoutes.CATALOG,
        Icon: IconBook,
    },
    {
        title: "Orders",
        link: AppRoutes.ORDERS,
        Icon: IconBrandTelegram,
    },
];

export const adminNavbarItems: INavbarItemProps[] = [
    {
        title: "Deliveries",
        link: AppRoutes.DELIVERIES,
        Icon: IconTruck,
    },
    {
        title: "Departments",
        link: AppRoutes.DEPARTMENTS,
        Icon: IconBuilding,
    },
]