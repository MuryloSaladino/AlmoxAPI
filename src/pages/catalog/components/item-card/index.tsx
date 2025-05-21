import type { Item } from "@/types/entities/items.types";
import { Badge, Box, Button, Card, Flex, Image, Menu, Select, Stack, Text } from "@mantine/core";
import { IconPlus, IconShoppingCart } from "@tabler/icons-react";
import { useContext, useState } from "react";
import { CatalogContext } from "../../context";
import { ItemsService } from "@/services/almox/items.service";

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
    const available = quantity > 0;

    const categoryOptions = ctxCategories.map(({ id, name }) => ({ label: name, value: id }));
    const categorize = async (categoryId: string | null) => {
        if(categoryId) {
            await ItemsService.categorize(id, categoryId);
            setCategories(prev => [...prev, ctxCategories.find(c => c.id == categoryId)!])
        }
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
                        <Box key={i} h={20} w={20} bg={c.color} style={{ borderRadius: "50%" }}/>
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
                
                <Button 
                    rightSection={<IconShoppingCart/>}
                    disabled={!available}
                >Add to Cart</Button>
            </Stack>
        </Card>
    )
}