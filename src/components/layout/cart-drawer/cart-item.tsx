import { OrdersService } from "@/services/almox/orders.service";
import type { ItemOrder } from "@/types/entities/items.types";
import { Button, Flex, Image, NumberInput, rem, Text } from "@mantine/core";
import { IconTrash } from "@tabler/icons-react";
import { useState } from "react";

export interface CartItemProps {
    item: ItemOrder;
    onDelete: () => void;
}

export function CartItem({ item, onDelete }: CartItemProps) {

    const [quantity, setQuantity] = useState(item.quantity);

    const updateQuantity = async () => {
        await OrdersService.addItem(item.id, quantity);
        item.quantity = quantity;
    }

    return (
        <Flex px={5} align="start" bd="1px solid rgba(0,0,0,.3)" pos="relative" gap={10} style={{ borderRadius: 5 }}>
            <Image src={item.imageUrl} alt={item.name} fit="cover" h={50} w={50}/>
            <Text fz={rem(14)} fw="bold" truncate="end" w={220}>{ item.name }</Text>
            <NumberInput
                w={70} h="100%" style={{ alignSelf: "center", marginLeft: "auto" }}
                value={quantity} onChange={(q) => setQuantity(Math.max(Number(q), 1))}
                onBlur={updateQuantity}
            />
            <Button onClick={onDelete} color="red" style={{ alignSelf: "center", marginLeft: "auto" }}>
                <IconTrash/>
            </Button>
        </Flex>
    )
}