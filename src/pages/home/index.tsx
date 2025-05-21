import { AppRoutes } from "@/config/constants/app-routes";
import { Button, Center, Group, Stack, TextInput, Title } from "@mantine/core";
import { IconSearch } from "@tabler/icons-react";

export function Home() {
    return (
        <Center h="80%">
            <Stack align="center" gap="lg">
                <Group>
                    <Title order={1}>Search items in our catalog</Title>
                    <IconSearch size={58}/>
                </Group>

                <form action={AppRoutes.CATALOG}>
                    <Group>
                        <TextInput name="name"/>
                        <Button type="submit">
                            <IconSearch/>
                        </Button>
                    </Group>
                </form>
            </Stack>
        </Center>
    )
}