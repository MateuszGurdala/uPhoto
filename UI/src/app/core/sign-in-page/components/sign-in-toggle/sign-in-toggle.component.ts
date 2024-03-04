import { Component, EventEmitter, Output } from '@angular/core';
import { NgClass } from '@angular/common';
import { SignInPage } from '../../enums/sign-in-page.enum';


@Component({
	selector: 'u-sign-in-toggle',
	standalone: true,
	imports: [
		NgClass
	],
	templateUrl: './sign-in-toggle.component.html',
	styleUrl: './sign-in-toggle.component.css'
})
export class SignInToggleComponent {
	@Output() pageSelect: EventEmitter<SignInPage> = new EventEmitter<SignInPage>();
	public currentPage: SignInPage = SignInPage.SignIn;
	public readonly pages: typeof SignInPage = SignInPage;

	public switchPage(page: SignInPage): void {
		if (this.currentPage !== page) {
			this.pageSelect.emit(page);
			this.currentPage = page;
		}
	}
}
