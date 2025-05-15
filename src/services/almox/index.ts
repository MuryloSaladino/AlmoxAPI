import { StorageKeys } from "@/config/constants/storage-keys";
import axios from "axios"

const almoxApi = axios.create({
    baseURL: import.meta.env.VITE_ALMOX_API_URL,
    headers: { "Content-Type": "application/json" },
    timeout: 10000,
})

almoxApi.interceptors.request.use((config) => {
    const token = localStorage.getItem(StorageKeys.TOKEN);
    
    if (token && config.headers) {
        config.headers.Authorization = `Bearer ${token}`;
    }

    return config;
});

export { almoxApi }