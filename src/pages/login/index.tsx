import { AuthService, type ILoginRequest } from "@/services/almox/auth.service";
import { Button, Center, Container, Flex, rem, Text, TextInput } from "@mantine/core";
import { IconAt, IconLock } from '@tabler/icons-react';
import { useForm } from '@mantine/form';
import { useNavigate } from "react-router";
import { AppRoutes } from "@/config/constants/app-routes";
import { StorageKeys } from "@/config/constants/storage-keys";
import { useContext } from "react";
import { UserContext } from "@/providers/user.context";
import { jwtDecode } from "jwt-decode"
import { Logo } from "@/components/brand/logo";
import { UsersService } from "@/services/almox/users.service";

export function Login() {

    const navigate = useNavigate();
    const { updateUser } = useContext(UserContext);
    const { key, onSubmit, getInputProps } = useForm<ILoginRequest>({
        initialValues: { password: "", username: "" },
    });
    
    const submit = async (request: ILoginRequest) => {
        const { token } = await AuthService.login(request);
        localStorage.setItem(StorageKeys.TOKEN, token);

        const { sub } = jwtDecode(token);
        const user = await UsersService.getById(sub!);
        updateUser(user);

        navigate(AppRoutes.ROOT);
    }

    return (
        <Center h="80vh">
            <Container 
                size="xs" w={rem(400)} maw="95%"
                px="md" py={rem(32)} bd="1px solid var(--mantine-color-default-border)"
            >
                <form onSubmit={onSubmit(submit)}>
                    <Flex direction="column" gap="lg">
                        <Logo style={{ alignSelf: "center" }}/>
                        <Text ta="center" fz={rem(18)}>Login to your account</Text>

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

                        <Button 
                            mt="sm" 
                            type="submit"
                            style={{ alignSelf: "end" }}
                        >Login</Button>
                    </Flex>
                </form>
            </Container>
        </Center>
    )
}