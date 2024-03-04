import { BackgroundColorReactDirective } from '../../../../shared/directives/background-color-react.directive';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { IconDirective } from '../../../../shared/directives/icon.directive';
import { InputComponent } from '../../../../shared/components/input/input.component';
import { NgOptimizedImage } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
	selector: 'u-sign-in-panel',
	standalone: true,
	imports: [
		InputComponent,
		IconDirective,
		ReactiveFormsModule,
		BackgroundColorReactDirective,
		NgOptimizedImage,
		RouterLink
	],
	templateUrl: './sign-in-panel.component.html',
	styleUrl: './sign-in-panel.component.css'
})
export class SignInPanelComponent {
	public formGroup: FormGroup = this.formBuilder.group({
		email: ['', {
			validators: [Validators.required, Validators.email]
		}],
		password: ['', {
			validators: [Validators.required]
		}]
	});

	constructor(private formBuilder: FormBuilder) {
	}
}
