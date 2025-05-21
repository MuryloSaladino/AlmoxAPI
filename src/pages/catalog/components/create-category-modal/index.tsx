import { notify } from "@/components/feedback/notifier/functions";
import { CategoriesService } from "@/services/almox/categories.service";
import type { CategoryCreation } from "@/types/entities/categories.types";
import { Button, ColorInput, Modal, Stack, TextInput } from "@mantine/core";
import { useForm } from "@mantine/form";
import { useContext } from "react";
import { CatalogContext } from "../../context";

export interface CreateCategoryModalProps {
    opened: boolean;
    onClose: () => void;
}

export function CreateCategoryModal({
    opened,
    onClose,
}: CreateCategoryModalProps) {

    const { updateCategories } = useContext(CatalogContext)

    const {
        key,
        getInputProps,
        onSubmit,
        reset,
    } = useForm<CategoryCreation>();

    const submit = async (data: CategoryCreation) => {
        await CategoriesService.create(data);
        notify.success("Category created!");
        onClose();
        reset();
        updateCategories();
    }

    return (
        <Modal
            title="Create category"
            opened={opened}
            onClose={onClose}
            withCloseButton
        >
            <form onSubmit={onSubmit(submit)}>
                <Stack>
                    <TextInput
                        label="Name"
                        key={key("name")}
                        {...getInputProps("name")}
                    />
                    <TextInput
                        label="Description"
                        key={key("description")}
                        {...getInputProps("description")}
                    />
                    <ColorInput
                        label="Color"
                        key={key("color")}
                        {...getInputProps("color")}
                    />
                    <Button type="submit" style={{ alignSelf: "flex-end" }}>Create</Button>
                </Stack>
            </form>
        </Modal>
    )
}