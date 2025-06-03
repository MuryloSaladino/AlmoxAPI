import { inject } from "@angular/core";
import { AuthService } from "../services/auth/auth.service";

export const authGuard = async () => {

	const auth = inject(AuthService);

	return Boolean(auth.user()) || await auth.tryCookiesAuth()
};
