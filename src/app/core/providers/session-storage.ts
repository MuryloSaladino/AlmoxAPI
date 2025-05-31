import { inject, Injectable, PLATFORM_ID } from "@angular/core";
import { isPlatformBrowser } from "@angular/common";

@Injectable({ providedIn: "root" })
export class SessionStorage {

	private readonly platformId = inject(PLATFORM_ID);
	private readonly isBrowser = isPlatformBrowser(this.platformId);

	getItem(key: string): string | null {
		return this.isBrowser ? sessionStorage.getItem(key) : null;
	}

	setItem(key: string, value: string): void {
		if (this.isBrowser) sessionStorage.setItem(key, value);
	}

	removeItem(key: string): void {
		if (this.isBrowser) sessionStorage.removeItem(key);
	}
}
