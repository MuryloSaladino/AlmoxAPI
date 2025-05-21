import { Button, Drawer, Stack, TextInput, Title } from "@mantine/core";
import { CategoryFilter } from "../category-filter";
import { IconFilter } from "@tabler/icons-react";
import { useSearchParams } from "react-router";
import { useState } from "react";

export interface FiltersDrawerProps {
    opened: boolean;
    onClose: () => void;
}

export function FiltersDrawer({
    opened,
    onClose,
}: FiltersDrawerProps) {

    const [query, setQuery] = useSearchParams();
    const [filters, setFilters] = useState({
        name: query.get("name") ?? "",
        category: query.get("category") ?? "",
    });

    const applyFilters = () => {
        setQuery(filters);
        onClose();
    }

    return (
        <Drawer opened={opened} onClose={onClose}>
            <Stack gap={40}>
                <Title order={3}>Filters</Title>
                <TextInput
                    label="Item name"
                    value={filters.name}
                    onChange={(e) => setFilters(prev => ({ ...prev, name: e.target.value }))}
                />
                <CategoryFilter 
                    value={filters.category} 
                    onChange={(category) => setFilters(prev => ({ ...prev, category }))}
                />
                <Button rightSection={<IconFilter/>} onClick={applyFilters}>Apply filters</Button>
            </Stack>
        </Drawer>
    )
}