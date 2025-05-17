import { NotificationColor, NotificationIcon, type NotificationType } from "@/config/constants/notifications";
import { EventEmitter, Events } from "@/providers/event-emitter"
import { Dialog, Notification, Text } from "@mantine/core"
import { useDisclosure } from "@mantine/hooks"
import { useEffect, useRef, useState } from "react"

export function Notifier() {

    const [opened, { open, close }] = useDisclosure(false);
    const [message, setMessage] = useState<string>();
    const [messageType, setMessageType] = useState<NotificationType>("Information");
    const timeoutRef = useRef<NodeJS.Timeout | null>(null);

    const notify = (data: any) => {
        if(timeoutRef.current)
            clearTimeout(timeoutRef.current);

        setMessage(data.message);
        setMessageType(data.type);
        open();

        timeoutRef.current = setTimeout(close, data.timeout);
    }

    useEffect(() => EventEmitter.subscribe(Events.NOTIFY, notify), [])

    const Icon = NotificationIcon[messageType];
    const color = NotificationColor[messageType];

    return (
        <Dialog
            opened={opened}
            shadow="none" bg="transparent" m="auto"
            position={{ top: 20, left: 0, right: 0 }}
        >
            <Notification
                icon={<Icon/>}
                title={messageType}
                color={color}
                onClose={close}
            >
                <Text>{ message }</Text>
            </Notification>
        </Dialog>
    )
}