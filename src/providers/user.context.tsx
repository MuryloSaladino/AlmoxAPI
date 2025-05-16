import type { IParentComponentProps } from "@/types/utils/component-utils.types";
import type { User } from "@/types/entities/user.types";
import { createContext, useState } from "react";

export interface IUserContext {
    user: User | null;
    updateUser: (user: User | null) => void;
}

export const UserContext = createContext({} as IUserContext);

export function UserContextProvider(props: IParentComponentProps) {

    const [user, setUser] = useState<User | null>(null);

    const updateUser = (user: User | null) => setUser(user);

    return <UserContext.Provider value={{ user, updateUser }} {...props}/>
}