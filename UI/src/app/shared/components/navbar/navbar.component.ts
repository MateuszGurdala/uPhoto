import { Component, EventEmitter, Output } from '@angular/core';
import { IconDirective } from '../../directives/icon.directive';
import { TextColorReactDirective } from '../../directives/text-color-react.directive';
import { RouterLink } from '@angular/router';

@Component({
	selector: 'u-navbar',
	standalone: true,
	imports: [
		IconDirective,
		TextColorReactDirective,
		RouterLink
	],
	templateUrl: './navbar.component.html',
	styleUrl: './navbar.component.css'
})
export class NavbarComponent {
	@Output() showAllApps: EventEmitter<void> = new EventEmitter<void>();

	public onShowAllApps(): void {
		this.showAllApps.emit();
	}
}
