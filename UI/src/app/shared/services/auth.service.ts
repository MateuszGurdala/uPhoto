import { Injectable } from '@angular/core';
import { StorageKeys } from '../enums/storage-keys.enum';
import moment, { Moment } from 'moment';

@Injectable({
	providedIn: 'root'
})
export class AuthService {
	public set expirationDate(date: Moment | null) {
		!!date
			? localStorage.setItem(StorageKeys.SessionExpirationDate, String(date))
			: localStorage.removeItem(StorageKeys.SessionExpirationDate);
	}

	public get getExpirationDate(): Moment | null {
		const date: string | null = localStorage.getItem(StorageKeys.SessionExpirationDate);
		return date ? moment(date) : null;
	}

	public isSessionValid(): boolean {
		const expirationDate: Moment | null = this.getExpirationDate;
		return expirationDate ? moment().utc() <= expirationDate : false;
	}

	public extendSession(): boolean {
		if (this.isSessionValid()) {
			this.expirationDate = moment().utc().add(10, 'minutes');
			return true;
		}
		return false;
	}
}
