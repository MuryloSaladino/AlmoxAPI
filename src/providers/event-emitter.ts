export const Events = {
    NOTIFY: "notify",
    REFRESH: "refresh",
} as const

export interface IEventEmitter {
    _events: { [key: string]: ((data: any) => void)[] };
    dispatch(event: string, data: any): void;
    subscribe(event: string, callback: (data: any) => any): (() => void);
    unsubscribe(event: string): void;
}

export const EventEmitter: IEventEmitter = {
    _events: {},
    
    dispatch(event: string, data: any) {
        if (!this._events[event]) return;
        this._events[event].forEach(callback => callback(data))
    },

    subscribe(event: string, callback: (data: any) => any) {
        if (!this._events[event]) this._events[event] = [];
        this._events[event].push(callback);
        return () => {
            this._events[event] = this._events[event].filter(cb => cb !== callback);
        };
    },
    
    unsubscribe(event: string) {
        if (!this._events[event]) return;
        delete this._events[event];
    }
}