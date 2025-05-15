import { login, type ILoginRequest } from "@/services/almox/auth";
import { Button, Center, Container, Flex, rem, TextInput, Title } from "@mantine/core";
import { IconAt, IconLock } from '@tabler/icons-react';
import { useForm } from '@mantine/form';
import { Logo } from "@/components/brand/logo";
import { useNavigate } from "react-router";
import { AppRoutes } from "@/config/constants/app-routes";
import { StorageKeys } from "@/config/constants/storage-keys";

export function Login() {

    const { key, onSubmit, getInputProps } = useForm<ILoginRequest>();
    const navigate = useNavigate();

    const submit = async (request: ILoginRequest) => {
        const { data } = await login(request);
        localStorage.setItem(StorageKeys.TOKEN, data.token)

        navigate(AppRoutes.ROOT);
    }

    return (
        <Center h="80vh">
            <Container 
                size="xs" w={rem(400)} maw="95%"
                px="md" py={rem(32)} bd="1px solid var(--mantine-color-default-border)"
            >
                <form onSubmit={onSubmit(submit)}>
                    <Flex 
                        direction="column" 
                        gap="md"
                    >
                        <Logo/>
                        <Title order={4} ta="center">Login to your account</Title>

                        <TextInput 
                            key={key("username")}
                            {...getInputProps("username")}
                            label="Username"
                            leftSection={<IconAt/>}
                            required
                        />

                        <TextInput
                            key={key("password")}
                            {...getInputProps("password")}
                            label="Password"
                            type="password"
                            leftSection={<IconLock/>}
                            required
                        />

                        <Button mt="sm" type="submit">Login</Button>
                    </Flex>
                </form>
            </Container>
        </Center>
    )
}