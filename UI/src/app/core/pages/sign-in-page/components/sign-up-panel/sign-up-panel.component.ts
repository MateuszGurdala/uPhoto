import { Component } from '@angular/core';
import { InputComponent } from '../../../../../shared/components/input/input.component';

@Component({
	selector: 'u-sign-up-panel',
	standalone: true,
	imports: [
		InputComponent
	],
	templateUrl: './sign-up-panel.component.html',
	styleUrl: './sign-up-panel.component.css'
})
export class SignUpPanelComponent {

}
