import { AuthService } from '../services/auth.service';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { catchError, Observable, ObservedValueOf, pipe, tap, UnaryFunction } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

	constructor(
		private authService: AuthService,
		private toastrService: ToastrService
	) {
	}

	intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
		return next.handle(req).pipe(
			this.handleErrors(),
			tap((resp: any) => {
				switch (true) {
				case resp instanceof HttpResponse:
					if (resp.status === 200 && this.authService.isSessionValid())
						this.authService.extendSession();
					break;
				default:
					break;
				}
			})
		);
	}

	private handleErrors(): UnaryFunction<Observable<unknown>, Observable<ObservedValueOf<void> | unknown>> {
		return pipe(
			catchError((err, caught) => {
				switch (err.status) {
				case 500:
					this.toastrService.error('Please try again later.', 'Internal server error.');
					break;
				case 400:
					this.toastrService.error('Invalid request.');
					break;
				default:
					this.toastrService.error('Please try again later.', 'Unknown error.');
					break;
				}
				throw err;
			})
		);
	}
}
