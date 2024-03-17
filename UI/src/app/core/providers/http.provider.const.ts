import { EnvironmentProviders } from '@angular/core';
import { provideHttpClient, withFetch } from '@angular/common/http';

export const HttpProvider: EnvironmentProviders = provideHttpClient(withFetch());
