import { notify } from "@/components/notifier/functions";
import { NotificationMessages } from "@/config/constants/notifications";
import { StorageKeys } from "@/config/constants/storage-keys";
import axios, { AxiosError, type AxiosResponse } from "axios"

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

almoxApi.interceptors.response.use(
    (data: AxiosResponse<any, any>) => {
        if(import.meta.env.DEV) {
            console.log("Request: " + data.request)
            console.log("Response: " + data.data)
        }
        return data
    },
    (error: AxiosError<any>) => {
        notify.error(error.response?.data.message 
            || NotificationMessages.Error.Unknown.Undefined);
    }
)

export { almoxApi }