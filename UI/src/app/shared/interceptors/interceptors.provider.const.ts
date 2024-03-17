import { Provider } from '@angular/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './auth.interceptor';

export const InterceptorsProvider: Provider = {
	provide: HTTP_INTERCEPTORS, multi: true, useClass: AuthInterceptor
};
