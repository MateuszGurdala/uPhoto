import { Injectable } from '@angular/core';
import { StorageKeys } from '../../shared/enums/storage-keys.enum';
import moment, { Moment } from 'moment';

@Injectable({
	providedIn: 'root'
})
export class AuthService {
	public set expirationDate(date: Moment | null) {
		!!date
			? this.storage?.setItem(StorageKeys.SessionExpirationDate, String(date))
			: this.storage?.removeItem(StorageKeys.SessionExpirationDate);
	}

	public get getExpirationDate(): Moment | null {
		const date: string | null | undefined = this.storage?.getItem(StorageKeys.SessionExpirationDate);
		return date ? moment(date) : null;
	}

	private get storage(): Storage | null {
		return typeof window !== 'undefined'
			? localStorage
			: null;
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
