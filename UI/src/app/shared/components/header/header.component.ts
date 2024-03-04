import { Component } from '@angular/core';
import { NgTemplateOutlet } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
	selector: 'u-header',
	standalone: true,
	imports: [
		NgTemplateOutlet,
		RouterLink
	],
	templateUrl: './header.component.html',
	styleUrl: './header.component.css'
})
export class HeaderComponent {

}
