import { inject } from '@angular/core';
import { HttpInterceptorFn, HttpErrorResponse } from '@angular/common/http';
import { catchError, switchMap, throwError } from 'rxjs';
import { AuthService } from '../services/auth/auth.service';
import { Router } from '@angular/router';
import { AppRoutes } from '../constants/app-routes';

export const authInterceptor: HttpInterceptorFn = (req, next) => {

	const auth = inject(AuthService);
	const router = inject(Router);
	let isRefreshing = false;

	return next(req).pipe(
		catchError((error: HttpErrorResponse) => {
			if (error.status === 401 && !isRefreshing) {
				isRefreshing = true;

				return auth.refresh().pipe(
					switchMap(() => next(req)),
					catchError((refreshError) => {
						auth.userSubject.next(null);
						router.navigate([AppRoutes.LOGIN])
						return throwError(() => refreshError);
					})
				);
			}
			return throwError(() => error);
		})
	);
};
