import type { ParentComponent } from "@/types/utils/component-utils.types";
import type { User } from "@/types/entities/user.types";
import { createContext, useState } from "react";
import type { Order } from "@/types/entities/orders.types";

export interface IUserContext {
    user: User | null;
    updateUser: (user: User | null) => void;

    ongoingOrder: Order | null;
    updateOngoingOrder: (user: Order | null) => void;
}

export const UserContext = createContext({} as IUserContext);

export function UserContextProvider(props: ParentComponent) {

    const [user, setUser] = useState<User | null>(null);
    const [ongoingOrder, setOngoingOrder] = useState<Order | null>(null);

    const updateUser = (user: User | null) => setUser(user);
    const updateOngoingOrder = (order: Order | null) => setOngoingOrder(order);

    return <UserContext.Provider {...props} value={{ 
        user, 
        updateUser, 
        ongoingOrder,
        updateOngoingOrder, 
    }}/>
}