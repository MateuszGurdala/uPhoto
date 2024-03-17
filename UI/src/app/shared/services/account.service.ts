import { GenericResponse } from '../models/api/generic.response';
import { HttpClient } from '@angular/common/http';
import { HttpClientBase } from './http-client-base';
import { Injectable } from '@angular/core';
import { KeyValuePairModel } from '../models/utilities/key-value-pair.model';
import { tap } from 'rxjs';
import { Router } from '@angular/router';
import { SignInCommand } from '../../core/sign-in-page/models/sign-in.command';

@Injectable({
	providedIn: 'root'
})
export class AccountService extends HttpClientBase {
	private readonly controllerPrefix: string = 'UserAccount/';
	private readonly endpoints: KeyValuePairModel<string> = {
		createAccount: this.controllerPrefix + 'create-account',
		signIn: this.controllerPrefix + 'sign-in',
		signOut: this.controllerPrefix + 'sign-out'
	};

	constructor(
		httpClient: HttpClient,
		private router: Router
	) {
		super(httpClient);
	}

	public signIn(command: SignInCommand): void {
		this.post<GenericResponse>(this.endpoints['signIn'], command, {isAnonymous: true})
			.pipe(
				tap(() => this.router.navigate(['/app', 'home']))
			)
			.subscribe();
	}

	public signOut(): void {
		this.post<GenericResponse>(this.endpoints['signOut'], {})
			.pipe(
				tap(() => this.router.navigate(['/sign-in']))
			)
			.subscribe();
	}
}
