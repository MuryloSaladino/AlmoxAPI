import '@mantine/core/styles.css';

import { MantineProvider } from '@mantine/core';
import { Outlet } from 'react-router';
import { theme } from '@/config/mantine/theme';
import { UserContextProvider } from './providers/user.context';
import { Notifier } from './components/feedback/notifier';


export function App() {
    return (
        <MantineProvider theme={theme}>
            <UserContextProvider>
                <Outlet/>
            </UserContextProvider>
            <Notifier/>
        </MantineProvider>
    )
}
