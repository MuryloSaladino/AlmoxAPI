import { useEffect, useState } from "react";
import { Center, FileInput, Image, Stack, Text, type FileInputProps } from "@mantine/core";
import { IconCamera } from "@tabler/icons-react";
import { v4 as uuid } from "uuid";

export interface ImageInputProps extends FileInputProps {
    value: File | null;
}

export function ImageInput({ value, ...props }: ImageInputProps) {

    const [preview, setPreview] = useState<string | null>(null);
    const id = uuid();

    useEffect(() => {
        if (value) {
            const objectUrl = URL.createObjectURL(value);
            setPreview(objectUrl);

            return () => URL.revokeObjectURL(objectUrl);
        } else {
            setPreview(null);
        }
    }, [value]);

    return (
        <Stack gap="md" w="100%">
            <Center 
                component="label" 
                htmlFor={id}
                style={{ 
                    overflow: "hidden", 
                    height: 250, width: "100%",
                    border: "solid 1px #c9c9c9",
                    cursor: "pointer"
                }}
            >
                {
                    preview 
                    ? <Image src={preview} h={250} fit="contain"/> 
                    : <Stack align="center"><IconCamera/><Text>Item Photo</Text></Stack>
                }
            </Center>

            <FileInput 
                {...props} 
                id={id}
                pos="absolute" 
                style={{ opacity: 0,  }}
                valueComponent={(_) => <></>}
            />
        </Stack>
    );
}
