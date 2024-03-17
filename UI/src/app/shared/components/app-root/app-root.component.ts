import { BackgroundColorReactDirective } from '../../directives/background-color-react.directive';
import { Component } from '@angular/core';
import { HeaderComponent } from '../header/header.component';
import { IconDirective } from '../../directives/icon.directive';
import { NavbarComponent } from '../navbar/navbar.component';
import { NgClass } from '@angular/common';
import { RouterLink, RouterOutlet } from '@angular/router';
import { TextColorReactDirective } from '../../directives/text-color-react.directive';
import { AppsModalComponent } from '../apps-modal/apps-modal.component';
import { AccountService } from '../../services/account.service';

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
		AppsModalComponent
	],
	templateUrl: './app-root.component.html',
	styleUrl: './app-root.component.css'
})
export class AppRootComponent {
	
	constructor(private accountService: AccountService) {
	}

	public onSignOut(): void {
		this.accountService.signOut();
	}
}
