import { UserContext } from "@/providers/user.context";
import { OrdersService } from "@/services/almox/orders.service";
import { OrderPriorityList, type OrderPriority } from "@/types/entities/orders.types";
import { Badge, Box, Button, Drawer, Group, Modal, Select, Stack, Text, Textarea, Title } from "@mantine/core";
import { useDisclosure } from "@mantine/hooks";
import { IconCancel, IconCheck, IconShoppingCart } from "@tabler/icons-react";
import { useContext, useEffect, useState } from "react";
import { CartItem } from "./cart-item";
import { EventEmitter, Events } from "@/providers/event-emitter";
import { notify } from "@/components/feedback/notifier/functions";
import type { ItemOrder } from "@/types/entities/items.types";

export function CartDrawer() {
    
    const { ongoingOrder, updateOngoingOrder } = useContext(UserContext);
    const [opened, { open, close }] = useDisclosure();
    const [observations, setObservations] = useState<string | null>(null);
    const [itemToDelete, setItemToDelete] = useState<ItemOrder | null>(null);

    const updateOrder = () => OrdersService.start().then(o => updateOngoingOrder(o));
    useEffect(() => { updateOrder() }, [])
    useEffect(() => 
        EventEmitter.subscribe(
            Events.REFRESH,
            (key) => key == "cart" && updateOrder()
        ), []
    )

    const handleUpdatePriority = async (p: string | null) => {
        if(ongoingOrder && p) {
            await OrdersService.update(ongoingOrder.id, {
                priority: p as OrderPriority,
                observations: ongoingOrder.observations
            })
        }
    }

    const handleUpdateObservations = async () => {
        if(ongoingOrder) {
            await OrdersService.update(ongoingOrder.id, {
                priority: ongoingOrder.priority,
                observations
            })
            updateOngoingOrder({ ...ongoingOrder, observations })
        }
    }

    useEffect(() => {
        if(ongoingOrder) setObservations(ongoingOrder.observations);
    }, [ongoingOrder])

    const sendOrder = async () => {
        if(ongoingOrder && ongoingOrder.orderItems.length > 0) {
            await OrdersService.updateStatus(ongoingOrder.id, "Requested");
            await updateOrder();
            close();
            notify("Ordered items succesfully!")
        }
    }

    const deleteItem = async () => {
        if(itemToDelete) {
            await OrdersService.removeItem(itemToDelete.id)
            setItemToDelete(null);
            EventEmitter.dispatch(Events.REFRESH, "cart");
        }
    }

    return ongoingOrder && (
        <>
            <Button variant="white" p={0} pos="relative" onClick={open} style={{ overflow: "visible" }}>
                <IconShoppingCart color="orange"/>
                {ongoingOrder.orderItems.length > 0 &&
                    <Badge size="xs" color="red" pos="absolute" right={-10} top={0}>
                        { ongoingOrder.orderItems.length }
                    </Badge>
                }
            </Button>

            <Modal opened={Boolean(itemToDelete)} onClose={() => setItemToDelete(null)} zIndex={10000}>
                <Stack>
                    <Text>Are you sure you wish to remove this from the cart?</Text>
                    <Group style={{ alignSelf: "end" }}>
                        <Button variant="subtle" onClick={() => setItemToDelete(null)}>Cancel</Button>
                        <Button color="red" onClick={deleteItem}>Remove</Button>
                    </Group>
                </Stack>
            </Modal>
            
            <Drawer position="right" opened={opened} onClose={close}>
                <Stack>
                    <Group style={{ alignSelf: "center" }}>
                        <Title order={3} c="cyan">Order Cart</Title>
                        <IconShoppingCart color="orange"/>
                    </Group>

                    <Stack>
                        {ongoingOrder.orderItems.map(item => 
                            <CartItem item={item} key={item.id} onDelete={() => setItemToDelete(item)}/>
                        )}
                    </Stack>

                    <Select
                        label="Priority" 
                        data={OrderPriorityList}
                        defaultValue={ongoingOrder.priority}
                        onChange={handleUpdatePriority}
                    />

                    <Box pos="relative">
                        <Textarea
                            label="Observations"
                            value={observations ?? ""}
                            onChange={(e) => setObservations(e.target.value)}
                        />
                        {observations != ongoingOrder.observations &&
                            <Group pos="absolute" right={15} bottom={5}>
                                <IconCheck
                                    color="green"
                                    cursor="pointer"
                                    onClick={handleUpdateObservations}
                                />
                                <IconCancel
                                    color="red"
                                    cursor="pointer"
                                    onClick={() => setObservations(ongoingOrder.observations)}
                                />
                            </Group>
                        }
                    </Box>

                    <Button
                        color="cyan"
                        mt="auto"
                        onClick={sendOrder}
                        disabled={ongoingOrder.orderItems.length < 1 || observations != ongoingOrder.observations}
                    >Order items</Button>
                </Stack>
            </Drawer>
        </>
    )
}