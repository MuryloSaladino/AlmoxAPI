import '@mantine/core/styles.css';

import { MantineProvider } from '@mantine/core';
import { Outlet } from 'react-router';
import { theme } from '@/config/mantine/theme';


export function App() {
    return (
        <MantineProvider theme={theme}>
            <Outlet/>
        </MantineProvider>
    )
}
