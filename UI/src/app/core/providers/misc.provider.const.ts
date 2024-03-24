import { EnvironmentProviders } from '@angular/core';
import { provideToastr } from 'ngx-toastr';

export const MiscProvider: EnvironmentProviders[] = [
	provideToastr({
		preventDuplicates: true,
		maxOpened: 5,
		progressBar: true,
		progressAnimation: 'increasing',
		timeOut: 2500,
	})
];
