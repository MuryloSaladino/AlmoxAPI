import { DepartmentsService } from "@/services/almox/departments.service";
import type { Department } from "@/types/entities/departments.types";
import { Button, Group, Stack, Text, Title } from "@mantine/core";
import { useDisclosure } from "@mantine/hooks";
import { IconPlus, IconX } from "@tabler/icons-react";
import { useEffect, useState } from "react";
import { useSearchParams } from "react-router";
import { CreateUser } from "../create-user";
import { EventEmitter, Events } from "@/providers/event-emitter";

export function DepartmentDetails() {

    const [department, setDepartment] = useState<Department | null>();
    const [searchParams, setSearchParams] = useSearchParams();
    const [opened, { open, close }] = useDisclosure(false);

    const updateDepartment = async () => {
        const departmentId = searchParams.get("departmentId");

        if(departmentId) {
            const response = await DepartmentsService.getById(departmentId);
            setDepartment(response);
        } else {
            setDepartment(null);
        }
    }

    useEffect(() => {
        updateDepartment();
    }, [searchParams])

    useEffect(() => EventEmitter.subscribe(Events.REFRESH, updateDepartment), []);

    return department && (
        <>
            <CreateUser opened={opened} onClose={close}/>

            <Stack
                gap="md" p="xl" pos="relative" h="100%"
                style={{ borderLeft: "1px solid gray" }}
            >
                <Button 
                    variant="white" 
                    onClick={() => setSearchParams()}
                    leftSection={<IconX color="red"/>}
                    pos="absolute" p={0}
                    right={20} top={20}
                />

                <Title order={2}>{ department.name }</Title>

                <Group>
                    <Title order={4}>Department Users</Title>
                    <Button 
                        variant="white" p={0}
                        onClick={open}
                        leftSection={<IconPlus/>}
                    />
                </Group>

                <Stack>
                    {department.users.map(user => (
                        <Text key={user.id}>
                            { user.username }  |  { user.email }
                        </Text>
                    ))}
                </Stack>
            </Stack>
        </>
    )
}