import { notify } from "@/components/feedback/notifier/functions";
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
    (data: AxiosResponse<any, any>) => data,
    (error: AxiosError<any>) => {
        switch(error.status) {
            case 401:
                break;
            default:
                notify.error(error.response?.data.message 
                    || NotificationMessages.Error.Unknown.Undefined);
                break;
        }
        throw error
    }
)

export { almoxApi }