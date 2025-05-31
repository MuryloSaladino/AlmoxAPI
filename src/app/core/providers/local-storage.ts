import { inject, Injectable, PLATFORM_ID } from "@angular/core";
import { isPlatformBrowser } from "@angular/common";

@Injectable({ providedIn: "root" })
export class LocalStorage {

	private readonly platformId = inject(PLATFORM_ID);
	private readonly isBrowser = isPlatformBrowser(this.platformId);

	getItem(key: string): string | null {
		return this.isBrowser ? localStorage.getItem(key) : null;
	}

	setItem(key: string, value: string): void {
		if (this.isBrowser) localStorage.setItem(key, value);
	}

	removeItem(key: string): void {
		if (this.isBrowser) localStorage.removeItem(key);
	}
}
