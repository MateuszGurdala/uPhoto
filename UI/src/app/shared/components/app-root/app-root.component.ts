import { BackgroundColorReactDirective } from '../../directives/background-color-react.directive';
import { Component } from '@angular/core';
import { HeaderComponent } from '../header/header.component';
import { IconDirective } from '../../directives/icon.directive';
import { NavbarComponent } from '../navbar/navbar.component';
import { NgClass } from '@angular/common';
import { RouterLink, RouterOutlet } from '@angular/router';
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
		RouterOutlet
	],
	templateUrl: './app-root.component.html',
	styleUrl: './app-root.component.css'
})
export class AppRootComponent {
}