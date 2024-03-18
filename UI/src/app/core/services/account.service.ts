import { AuthService } from './auth.service';
import { HttpClient } from '@angular/common/http';
import { HttpClientBase } from './http-client-base';
import { Injectable } from '@angular/core';
import { KeyValuePairModel } from '../../shared/models/utilities/key-value-pair.model';
import { Router } from '@angular/router';
import { SignInCommand } from '../pages/sign-in-page/models/sign-in.command';
import { SignInResponse } from '../pages/sign-in-page/models/sign-in.response';
import { tap } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class AccountService extends HttpClientBase {
	private readonly controllerPrefix: string = 'user-account/';
	private readonly endpoints: KeyValuePairModel<string> = {
		createAccount: this.controllerPrefix + 'create-account',
		signIn: this.controllerPrefix + 'sign-in',
		signOut: this.controllerPrefix + 'sign-out'
	};

	constructor(
		httpClient: HttpClient,
		private authService: AuthService,
		private router: Router,
	) {
		super(httpClient);
	}

	public signIn(command: SignInCommand): void {
		this.post<SignInResponse>(this.endpoints['signIn'], command, {isAnonymous: true})
			.pipe(
				tap((response: SignInResponse): void => {
					this.authService.expirationDate = response.expires;
					void this.router.navigate(['/app', 'home']);
				})
			)
			.subscribe();
	}

	public signOut(): void {
		this.post(this.endpoints['signOut'], {})
			.pipe(
				tap((): void => {
					this.authService.expirationDate = null;
					void this.router.navigate(['/sign-in']);
				})
			)
			.subscribe();
	}
}
