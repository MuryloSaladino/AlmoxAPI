import { EventEmitter, Events } from "@/providers/event-emitter";
import { UsersService } from "@/services/almox/users.service";
import type { UserCreation } from "@/types/entities/user.types";
import { Button, Checkbox, Modal, Stack, TextInput } from "@mantine/core";
import { useForm } from "@mantine/form";
import { useEffect, useState } from "react";
import { useSearchParams } from "react-router";

export interface CreateUserProps {
    opened: boolean;
    onClose: () => void;
}

export function CreateUser({
    opened, onClose,
}: CreateUserProps) {

    const [searchParams] = useSearchParams();
    const [departmentId, setDepartmentId] = useState(searchParams.get("departmentId")!);

    useEffect(() => {
        setDepartmentId(searchParams.get("departmentId")!)
    }, [opened])

    const { key, onSubmit, getInputProps, reset } = useForm<UserCreation>({
        initialValues: { 
            username: "",
            email: "",
            departmentId: "",
            password: "",
            isAdmin: false,
        },
    });

    const submit = async (data: UserCreation) => {
        reset();
        await UsersService.register({ ...data, departmentId });
        EventEmitter.dispatch(Events.REFRESH, {});
        onClose();
    }

    return (
        <Modal opened={opened} onClose={onClose} title="Create User">
            <form onSubmit={onSubmit(submit)}>
                <Stack gap="md">

                    <TextInput
                        key={key("username")}
                        label="Username"
                        {...getInputProps("username")}
                        required
                    />

                    <TextInput
                        key={key("email")}
                        label="Email"
                        {...getInputProps("email")}
                        required
                    />

                    <TextInput
                        key={key("password")}
                        label="Password"
                        {...getInputProps("password")}
                        type="password"
                        required
                    />

                    <Checkbox
                        key={key("isAdmin")}
                        label="Administrator"
                        {...getInputProps("isAdmin")}
                    />
                    
                    <Button type="submit" style={{ alignSelf: "end" }}>
                        Create
                    </Button>

                </Stack>
            </form>
        </Modal>
    )
}