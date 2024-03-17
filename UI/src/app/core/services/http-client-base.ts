import { ApiRequestOptionsModel } from '../../shared/models/api/api-request-options.model';
import { ApiResponseModel } from '../../shared/models/api/api-response.model';
import { Directive } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { appClientConfig } from '../../app.config';
import { catchError, EMPTY, map, Observable, ObservedValueOf, of, pipe, switchMap, take, UnaryFunction } from 'rxjs';

@Directive()
export class HttpClientBase {
	private readonly headers: HttpHeaders = new HttpHeaders({
		'Content-Type': 'application/json'
	});

	constructor(private client: HttpClient) {
	}

	private get getErrorHandlingPipe():
		UnaryFunction<Observable<ApiResponseModel<any>>,
			Observable<ObservedValueOf<Observable<ApiResponseModel<any>>>>> {
		return pipe(
			catchError((err, caught: Observable<ApiResponseModel<any>>) => {
				return EMPTY;
			}),
			switchMap((response: ApiResponseModel<any>): Observable<ApiResponseModel<any>> => response.status === 200 ? of(response) : EMPTY),
		);
	}

	private get getCommonPipe(): UnaryFunction<Observable<ApiResponseModel<any>>, Observable<any>> {
		return pipe(
			map((apiResponse: ApiResponseModel<any>) => apiResponse.data ?? {}),
			take(1)
		);
	}

	protected get<T = {}>(endpoint: string, apiOptions?: ApiRequestOptionsModel): Observable<T> {
		return this.client.get<ApiResponseModel<T>>(appClientConfig.apiUrl + endpoint, {
			headers: this.headers,
			withCredentials: apiOptions?.isAnonymous ?? true
		}).pipe(this.getErrorHandlingPipe, this.getCommonPipe);
	}

	protected post<T = {}>(endpoint: string, payload: any, apiOptions?: ApiRequestOptionsModel): Observable<T> {
		return this.client.post<ApiResponseModel<T>>(appClientConfig.apiUrl + endpoint, payload, {
			headers: this.headers,
			withCredentials: apiOptions?.isAnonymous ?? true
		}).pipe(this.getErrorHandlingPipe, this.getCommonPipe);
	}

	protected put<T = {}>(endpoint: string, payload: any, apiOptions?: ApiRequestOptionsModel): Observable<T> {
		return this.client.post<ApiResponseModel<T>>(appClientConfig.apiUrl + endpoint, payload, {
			headers: this.headers,
			withCredentials: apiOptions?.isAnonymous ?? true
		}).pipe(this.getErrorHandlingPipe, this.getCommonPipe);
	}
}
