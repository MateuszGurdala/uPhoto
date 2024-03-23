import { AuthService } from './auth.service';
import { HttpClient } from '@angular/common/http';
import { HttpClientBase } from './http-client-base';
import { Injectable } from '@angular/core';
import { KeyValuePairModel } from '../../shared/models/utilities/key-value-pair.model';
import { Router } from '@angular/router';
import { SignInCommand } from '../pages/sign-in-page/models/sign-in.command';
import { SignInResponse } from '../pages/sign-in-page/models/sign-in.response';
import { Observable, of, pipe, switchMap, tap, UnaryFunction } from 'rxjs';

@Injectable({
	providedIn: 'root'
})
export class AccountService extends HttpClientBase {
	private requestOngoing: boolean = false;
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

		this.errorTopic.subscribe((): boolean => this.requestOngoing = false);
	}

	public get isProcessing(): boolean {
		return this.requestOngoing;
	}

	private get startProcessing(): UnaryFunction<Observable<boolean>, Observable<boolean>> {
		return pipe(tap((): boolean => this.requestOngoing = true));
	}

	private get finishProcessing(): UnaryFunction<Observable<any>, Observable<null>> {
		return pipe(tap((): boolean => this.requestOngoing = false));
	}

	public signIn(command: SignInCommand): void {
		of(true).pipe(
				this.startProcessing,
				switchMap(() => this.post<SignInResponse>(this.endpoints['signIn'], command, {isAnonymous: true})),
				tap((response: SignInResponse): void => {
					this.authService.expirationDate = response.expires;
					void this.router.navigate(['/app', 'home']);
				}),
				this.finishProcessing
			)
			.subscribe();
	}

	public signOut(): void {
		of(true).pipe(
				this.startProcessing,
				switchMap(() => this.post(this.endpoints['signOut'], {})),
				tap((): void => {
					this.authService.expirationDate = null;
					void this.router.navigate(['/sign-in']);
				}),
				this.finishProcessing
			)
			.subscribe();
	}
}
