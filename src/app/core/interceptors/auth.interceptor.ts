import { inject } from '@angular/core';
import { HttpInterceptorFn, HttpErrorResponse } from '@angular/common/http';
import { catchError, switchMap, throwError } from 'rxjs';
import { ApiService } from '../services/api/api.service';

export const authInterceptor: HttpInterceptorFn = (req, next) => {

	const api = inject(ApiService);
	let isRefreshing = false;

	return next(req).pipe(
		catchError((error: HttpErrorResponse) => {
			if (error.status === 401 && !isRefreshing) {
				isRefreshing = true;

				return api.refresh().pipe(
					switchMap(() => next(req)),
					catchError((refreshError) => {
						api.user.set(null);
						return throwError(() => refreshError);
					})
				);
			}

			return throwError(() => error);
		})
	);
};
