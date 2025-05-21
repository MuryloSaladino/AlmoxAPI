import { ImageInput } from "@/components/controls/image-input";
import { notify } from "@/components/feedback/notifier/functions";
import { EventEmitter, Events } from "@/providers/event-emitter";
import { ItemsService } from "@/services/almox/items.service";
import type { ItemCreation } from "@/types/entities/items.types";
import { Button, Modal, Stack, TextInput } from "@mantine/core";
import { useForm } from "@mantine/form";
import { useState } from "react";

export interface CreateItemModalProps {
    opened: boolean;
    onClose: () => void;
}

export function CreateItemModal({
    onClose,
    opened
}: CreateItemModalProps) {

    const {
        key,
        getInputProps,
        onSubmit,
        reset,
    } = useForm<ItemCreation>({
        initialValues: { name: "" }
    });

    const [file, setFile] = useState<File | null>(null);

    const submit = async (data: ItemCreation) => {
        const newItem = await ItemsService.create(data);
        
        if(file) await ItemsService.updateImage(newItem.id, file);

        EventEmitter.dispatch(Events.REFRESH, {});
        notify.success("New item created!");
        
        onClose();
        reset();
    } 
    
    return (
        <Modal
            opened={opened}
            onClose={onClose}
            withCloseButton
            title="Create new item"
        >
            <form onSubmit={onSubmit(submit)}>
                <Stack>
                    <ImageInput value={file} onChange={(file) => setFile(file)}/>
                    
                    <TextInput
                        label="Item name"
                        key={key("name")}
                        {...getInputProps("name")}
                    />

                    <Button type="submit">Create</Button>
                </Stack>
            </form>
        </Modal>
    )
}