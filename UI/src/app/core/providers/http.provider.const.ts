import { EnvironmentProviders } from '@angular/core';
import { provideHttpClient, withFetch, withInterceptorsFromDi } from '@angular/common/http';

export const HttpProvider: EnvironmentProviders = provideHttpClient(withFetch(), withInterceptorsFromDi());
