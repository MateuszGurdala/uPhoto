import { EnvironmentProviders } from '@angular/core';
import { provideClientHydration } from '@angular/platform-browser';
import { provideServerRendering } from '@angular/platform-server';

export const LazyLoadingProvider: EnvironmentProviders[] = [
	provideClientHydration(),
	provideServerRendering()
];
