import { Component } from '@angular/core';
import { HeaderComponent } from '../../shared/components/header/header.component';
import { Location, NgClass } from '@angular/common';
import { RouterLink } from '@angular/router';
import { SignInPage } from './enums/sign-in-page.enum';
import { SignInToggleComponent } from './components/sign-in-toggle/sign-in-toggle.component';
import { Title } from '@angular/platform-browser';
import { InputComponent } from '../../shared/components/input/input.component';
import { SignInPanelComponent } from './components/sign-in-panel/sign-in-panel.component';
import { SignUpPanelComponent } from './components/sign-up-panel/sign-up-panel.component';

@Component({
	selector: 'app-sign-in-page',
	standalone: true,
	imports: [
		HeaderComponent,
		RouterLink,
		SignInToggleComponent,
		NgClass,
		InputComponent,
		SignInPanelComponent,
		SignUpPanelComponent
	],
	templateUrl: './sign-in-page.component.html',
	styleUrl: './sign-in-page.component.css'
})
export class SignInPageComponent {
	public currentPage: SignInPage = SignInPage.SignIn;
	public readonly pages: typeof SignInPage = SignInPage;

	constructor(private location: Location,
		private title: Title) {
	}

	public onPageSelect(page: SignInPage): void {
		this.currentPage = page;
		this.title.setTitle(page === SignInPage.SignIn ? 'Sign In' : 'Sign Up');
		this.location.go(page);
	}
}
