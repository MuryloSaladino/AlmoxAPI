import { inject } from "@angular/core";
import { AuthService } from "../services/auth/auth.service";
import { map } from "rxjs";

export const authGuard = () => {

	const auth = inject(AuthService);

	if(auth.userSubject.value)
		return true;

	return auth.tryCookiesAuth().pipe(map(() => {
		return Boolean(auth.userSubject.value);
	}));
};
