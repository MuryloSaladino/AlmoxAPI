import type { Item } from "@/types/entities/items.types";
import { Badge, Box, Button, Card, Flex, Group, Image, Menu, NumberInput, Select, Stack, Text, Tooltip } from "@mantine/core";
import { IconCheck, IconPlus, IconShoppingCart } from "@tabler/icons-react";
import { useContext, useState } from "react";
import { CatalogContext } from "../../context";
import { ItemsService } from "@/services/almox/items.service";
import { OrdersService } from "@/services/almox/orders.service";
import { useDisclosure } from "@mantine/hooks";
import { EventEmitter, Events } from "@/providers/event-emitter";

export interface ItemCardProps {
    item: Item;
    editable?: boolean;
}

export function ItemCard({ editable, item: {
    id,
    name,
    imageUrl,
    quantity,
    categories: srcCategories,
}}: ItemCardProps) {

    const { categories: ctxCategories } = useContext(CatalogContext);
    const [categories, setCategories] = useState(srcCategories);
    const [orderQuantity, setOrderQuantity] = useState(1);
    const [opened, { close, open }] = useDisclosure();
    const available = quantity > 0;

    const categoryOptions = ctxCategories.map(({ id, name }) => ({ label: name, value: id }));
    const categorize = async (categoryId: string | null) => {
        if(categoryId) {
            await ItemsService.categorize(id, categoryId);
            setCategories(prev => [...prev, ctxCategories.find(c => c.id == categoryId)!])
        }
    }

    const addItemToCart = async () => {
        await OrdersService.addItem(id, orderQuantity);
        setOrderQuantity(1);
        close();
        EventEmitter.dispatch(Events.REFRESH, "cart");
    }

    return (
        <Card w="100%" shadow="md" h={380}>
            <Card.Section pos="relative">
                <Image
                    src={imageUrl}
                    alt={name}
                    height={250}
                    fit="contain"
                />
                
                <Badge 
                    color={ available ? "green" : "red" }
                    pos="absolute" right={20} top={200}
                >
                    { available ? "Available" : "Out of stock" }
                </Badge>

                <Flex pos="absolute" left={20} top={20} gap={5}>
                    {categories.map((c, i) => 
                        <Tooltip label={c.name}>
                            <Box key={i} h={20} w={20} bg={c.color} style={{ borderRadius: "50%" }}/>
                        </Tooltip>
                    )}

                    {editable &&
                        <Menu>
                            <Menu.Target>
                                <Button h={20} w={20} p={0} bg="blue" style={{ borderRadius: "50%" }}><IconPlus/></Button>
                            </Menu.Target>
                            <Menu.Dropdown>
                                <Select
                                    label="Add category" 
                                    data={categoryOptions}
                                    onChange={categorize}
                                />
                            </Menu.Dropdown>
                        </Menu>
                    }
                </Flex>
            </Card.Section>
            
            <Stack mt={10} h="100%" justify="space-between">
                <Text fw={500}>{ name }</Text>
                
                <Menu opened={opened} onClose={close} onOpen={open}>
                    <Menu.Target>
                        <Button rightSection={<IconShoppingCart/>} disabled={!available}>Add to Cart</Button>
                    </Menu.Target>
                    <Menu.Dropdown>
                        <Group>
                            <NumberInput 
                                defaultValue={1}
                                value={orderQuantity}
                                onChange={(e) => setOrderQuantity(Number(e) || 1)}
                            />
                            <Button color="green" px={10} onClick={addItemToCart}><IconCheck/></Button>
                        </Group>
                    </Menu.Dropdown>
                </Menu>
            </Stack>
        </Card>
    )
}