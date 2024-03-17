import { AccountService } from '../../../../services/account.service';
import { BackgroundColorReactDirective } from '../../../../../shared/directives/background-color-react.directive';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { IconDirective } from '../../../../../shared/directives/icon.directive';
import { InputComponent } from '../../../../../shared/components/input/input.component';
import { NgOptimizedImage } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
	selector: 'u-sign-in-panel',
	standalone: true,
	imports: [
		BackgroundColorReactDirective,
		IconDirective,
		InputComponent,
		NgOptimizedImage,
		ReactiveFormsModule,
		RouterLink
	],
	templateUrl: './sign-in-panel.component.html',
	styleUrl: './sign-in-panel.component.css'
})
export class SignInPanelComponent {
	public formGroup: FormGroup = this.formBuilder.group({
		email: ['test@gmail.com', {
			validators: [Validators.required, Validators.email]
		}],
		password: ['testPassword123', {
			validators: [Validators.required]
		}]
	});

	constructor(
		private accountService: AccountService,
		private formBuilder: FormBuilder,
	) {
	}

	public onSignIn(): void {
		if (this.formGroup.valid) {
			this.accountService.signIn({
				email: this.formGroup.get('email')?.getRawValue(),
				password: this.formGroup.get('password')?.getRawValue()
			});
		}
	}
}
