import { ApplicationConfig } from '@angular/core';
import { HttpProvider } from './core/providers/http.provider.const';
import { InterceptorsProvider } from './core/providers/interceptors.provider.const';
import { LazyLoadingProvider } from './core/providers/lazy-loading.provider.const';
import { MiscProvider } from './core/providers/misc.provider.const';
import { RouterProvider } from './core/providers/router.provider.const';

export const appClientConfig = {
	apiUrl: 'http://localhost:5159/api/',
	sessionLifespan: 10 //minutes
};

export const appConfig: ApplicationConfig = {
	providers: [
		HttpProvider,
		InterceptorsProvider,
		LazyLoadingProvider,
		RouterProvider,
		MiscProvider
	]
};
