import { AccountService } from '../../../core/services/account.service';
import { AppsModalComponent } from '../apps-modal/apps-modal.component';
import { BackgroundColorReactDirective } from '../../directives/background-color-react.directive';
import { Component } from '@angular/core';
import { HeaderComponent } from '../header/header.component';
import { IconDirective } from '../../directives/icon.directive';
import { NavbarComponent } from '../navbar/navbar.component';
import { NgClass, NgIf } from '@angular/common';
import { RouterLink, RouterOutlet } from '@angular/router';
import { SpinnerComponent } from '../spinner/spinner.component';
import { TextColorReactDirective } from '../../directives/text-color-react.directive';

@Component({
	selector: 'u-app-root',
	standalone: true,
	imports: [
		BackgroundColorReactDirective,
		HeaderComponent,
		RouterLink,
		TextColorReactDirective,
		IconDirective,
		NavbarComponent,
		NgClass,
		RouterOutlet,
		AppsModalComponent,
		SpinnerComponent,
		NgIf
	],
	templateUrl: './app-root.component.html',
	styleUrl: './app-root.component.css'
})
export class AppRootComponent {

	constructor(private accountService: AccountService) {
	}

	public get isProcessingRequest(): boolean {
		return this.accountService.isProcessing;
	}

	public onSignOut(): void {
		this.accountService.signOut();
	}
}
