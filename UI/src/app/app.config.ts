import { ApplicationConfig } from '@angular/core';
import { provideClientHydration } from '@angular/platform-browser';
import { provideHttpClient, withFetch } from '@angular/common/http';
import { provideRouter } from '@angular/router';
import { provideServerRendering } from '@angular/platform-server';
import { routes } from './app.routes';

export const appClientConfig = {
	apiUrl: 'http://localhost:5159/api/'
};

export const appConfig: ApplicationConfig = {
	providers: [
		provideClientHydration(),
		provideHttpClient(withFetch()),
		provideRouter(routes),
		provideServerRendering(),
	]
};
