import { Button, Grid, Group, Stack, Title } from "@mantine/core";
import { DepartmentsTable } from "./components/departments-table";
import { IconPlus } from "@tabler/icons-react";
import { useDisclosure } from "@mantine/hooks";
import { CreateDepartment } from "./components/create-department";
import { DepartmentDetails } from "./components/department-details";
import { useSearchParams } from "react-router";

export function Departments() {

    const [opened, { open, close }] = useDisclosure(false);

    const [searchParams] = useSearchParams();
    const departmentId = searchParams.get("departmentId");

    return (
        <>  
            <CreateDepartment opened={opened} onClose={close}/>

            <Stack gap="xl">
                <Group>
                    <Title>Departments</Title>
                    <Button 
                        variant="white" 
                        onClick={open}
                        rightSection={<IconPlus/>}
                    />
                </Group>

                <Grid>
                    <Grid.Col span={{ xs: 12, md: departmentId ? 6 : 12 }}>
                        <DepartmentsTable/>
                    </Grid.Col>
                    <Grid.Col span={{ xs: 12, md: 6 }}>
                        <DepartmentDetails/>
                    </Grid.Col>
                </Grid>
            </Stack>
        </>
    )
}