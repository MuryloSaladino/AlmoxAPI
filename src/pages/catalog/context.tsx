import { CategoriesService } from "@/services/almox/categories.service";
import type { CategorySummary } from "@/types/entities/categories.types";
import type { ParentComponent } from "@/types/utils/component-utils.types";
import { createContext, useEffect, useState } from "react";

export interface CatalogContext {
    categories: CategorySummary[];
    updateCategories: () => void;
}

export const CatalogContext = createContext({} as CatalogContext); 

export function CatalogContextProvider(props: ParentComponent) {

    const [categories, setCategories] = useState<CategorySummary[]>([]);

    const updateCategories = () => CategoriesService.get().then(res => setCategories(res));

    useEffect(() => { updateCategories() }, []);

    return <CatalogContext.Provider value={{ categories, updateCategories }} {...props}/>
}