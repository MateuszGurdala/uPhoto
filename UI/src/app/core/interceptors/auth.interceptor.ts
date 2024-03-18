import {
	HttpEvent,
	HttpHandler,
	HttpHeaderResponse,
	HttpInterceptor,
	HttpProgressEvent,
	HttpRequest,
	HttpResponse,
	HttpSentEvent,
	HttpUserEvent
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

	constructor(private authService: AuthService) {
	}

	intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
		return next.handle(req).pipe(
			tap((resp: HttpSentEvent | HttpHeaderResponse | HttpResponse<any> | HttpProgressEvent | HttpUserEvent<any>) => {
				if (resp instanceof HttpResponse &&
					resp.status === 200 &&
					this.authService.isSessionValid()
				) {
					this.authService.extendSession();
				}
			})
		);
	}
}
