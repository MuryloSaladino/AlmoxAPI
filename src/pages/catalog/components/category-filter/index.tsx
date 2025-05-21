import { Button, Chip, Group, Stack, Text } from "@mantine/core";
import { IconPlus } from "@tabler/icons-react";
import { useContext } from "react";
import { CreateCategoryModal } from "../create-category-modal";
import { useDisclosure } from "@mantine/hooks";
import { CatalogContext } from "../../context";

export interface CategoryFilterProps {
    value: string;
    onChange: (category: string) => void; 
}

export function CategoryFilter({
    value,
    onChange,
}: CategoryFilterProps) {

    const { categories } = useContext(CatalogContext);
    const [opened, { open, close }] = useDisclosure(false);

    return(
        <>
            <CreateCategoryModal opened={opened} onClose={close}/>

            <Stack>
                <Text fz="sm" fw={600}>Category</Text>
                <Group gap="xs">
                    {categories.map(c => 
                        <Chip
                            checked={value == c.name} 
                            onClick={() => onChange(value == c.name ? "" : c.name)}
                            color={c.color}
                        >{ c.name }</Chip>
                    )}
                    <Button 
                        h={28}
                        variant="light" 
                        style={{ borderRadius: 15 }}
                        onClick={open}
                    ><IconPlus/></Button>
                </Group>
            </Stack>
        </>        
    )
}