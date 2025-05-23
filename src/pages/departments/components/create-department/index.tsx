import { EventEmitter, Events } from "@/providers/event-emitter";
import { DepartmentsService } from "@/services/almox/departments.service";
import type { DepartmentCreation } from "@/types/entities/departments.types";
import { Button, Modal, Stack, TextInput } from "@mantine/core";
import { useForm } from "@mantine/form";
import { IconBuilding } from "@tabler/icons-react";

export interface CreateDepartmentProps {
    opened: boolean;
    onClose: () => void;
}

export function CreateDepartment({
    opened,
    onClose,
}: CreateDepartmentProps) {

    const { key, onSubmit, getInputProps, reset } = useForm<DepartmentCreation>({
        initialValues: { name: "" },
    });

    const submit = async (data: DepartmentCreation) => {
        reset();
        await DepartmentsService.create(data);
        EventEmitter.dispatch(Events.REFRESH, "departments");
        onClose();
    }

    return (
        <Modal opened={opened} onClose={onClose} title="Create Department">
            <form onSubmit={onSubmit(submit)}>
                <Stack gap="md">

                    <TextInput
                        key={key("name")}
                        label="Name"
                        {...getInputProps("name")}
                        leftSection={<IconBuilding/>}
                        required
                    />
                    
                    <Button type="submit" style={{ alignSelf: "end" }}>
                        Create
                    </Button>

                </Stack>
            </form>
        </Modal>
    )
}