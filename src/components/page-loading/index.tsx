import { Center, Loader } from "@mantine/core";

export function PageLoading() {
    return (
        <Center h="100vh" w="100vw">
            <Loader 
                type="bars" 
                color="cyan"
                size="xl"
            />
        </Center>
    )
}