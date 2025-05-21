import type { Item } from "@/types/entities/items.types";
import { Button, Center, Flex, Grid, Group, rem, Skeleton, Text, Title } from "@mantine/core";
import { useContext, useEffect, useState } from "react"
import { ItemCard } from "./components/item-card";
import { ItemsService } from "@/services/almox/items.service";
import { CreateItemModal } from "./components/create-item-modal";
import { useDisclosure } from "@mantine/hooks";
import { UserContext } from "@/providers/user.context";
import { IconFilter, IconPlus, IconShieldLock } from "@tabler/icons-react";
import { useLocation } from "react-router";
import { FiltersDrawer } from "./components/filters-drawer";
import { CatalogContextProvider } from "./context";

export function Catalog() {

    const { user } = useContext(UserContext);
    const [items, setItems] = useState<Item[]>([]);
    const [loading, setLoading] = useState(false);
    const [opened, { open, close }] = useDisclosure(false);
    const [drawerOpened, { open: openDrawer, close: closeDrawer }] = useDisclosure(false);
    const location = useLocation();

    const updateItems = async () => {
        setLoading(true);
        const response = await ItemsService.get(location.search);
        setItems(response);
        setLoading(false);
    }

    useEffect(() => { updateItems() }, [location]);

    return (
        <CatalogContextProvider>
            {user?.isAdmin &&
                <CreateItemModal opened={opened} onClose={close}/>
            }

            <Flex align="center" justify="space-between">
                <Group>
                    <Title>Catalog</Title>
                    <Button
                        onClick={openDrawer}
                        rightSection={<IconFilter/>}
                        bg="grape"
                    >Filters</Button>
                </Group>

                {user?.isAdmin &&
                    <Button onClick={open} px={10}>
                        <IconShieldLock/><IconPlus/>
                    </Button>
                }
            </Flex>

            <FiltersDrawer opened={drawerOpened} onClose={closeDrawer}/>

            <Center mih={400}>
                <Grid w="95%" maw={1200} gutter="xl" my={70}>
                    {
                        loading
                        ? Array(10).fill(null).map((_, i) => 
                            <Grid.Col key={i} span={{ base: 12, md: 6, lg: 4, xl: 3 }}>
                                <Skeleton visible={true} h={380}/>
                            </Grid.Col>
                        )
                        : items.length > 0
                        ? items.map(item => 
                            <Grid.Col key={item.id} span={{ base: 12, md: 6, lg: 4, xl: 3 }}>
                                <ItemCard item={item} editable={user?.isAdmin}/>
                            </Grid.Col>
                        ) : (
                            <Grid.Col span={12}>
                                <Text fz={rem(32)} ta="center">No item were found.</Text>
                            </Grid.Col>
                        )
                    }
                </Grid>
            </Center>
        </CatalogContextProvider>
    )
}