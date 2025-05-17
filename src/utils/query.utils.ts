export const Query = {
    fromObject: function (obj?: { [key: string]: string | number }): string {
        let query = "";

        if(obj) {
            Object.entries(obj).forEach(([key, value], index) => {
                if(value) {
                    const initial = index == 0 ? "?" : "&";
                    query += `${initial}${key}=${value}`;
                }
            });
        }

        return query;
    }
} as const;
