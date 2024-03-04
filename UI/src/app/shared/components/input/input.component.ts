import { Component, Input } from '@angular/core';
import { ControlValueAccessor, FormControl, NG_VALUE_ACCESSOR, ReactiveFormsModule } from '@angular/forms';
import { IconDirective } from '../../directives/icon.directive';
import { TextColorReactDirective } from '../../directives/text-color-react.directive';
import { NgClass } from '@angular/common';

@Component({
	selector: 'u-input',
	standalone: true,
	imports: [
		TextColorReactDirective,
		IconDirective,
		ReactiveFormsModule,
		NgClass
	],
	templateUrl: './input.component.html',
	styleUrl: './input.component.css',
	providers: [
		{
			provide: NG_VALUE_ACCESSOR,
			multi: true,
			useExisting: InputComponent
		}
	]
})
export class InputComponent implements ControlValueAccessor {
	@Input() label: string;
	@Input() size: number = 2;
	@Input() type: string = 'text';
	public readonly inputFormControl: FormControl<string | null> = new FormControl<string | null>('');
	private readonly labelSizeRatio: number = 0.8;
	private readonly clearBtnSizeRatio: number = 1.2;

	public get getInputDynamicStyles(): string {
		return `font-size: ${this.size}em;`;
	}

	public get getLabelDynamicStyles(): string {
		return `font-size: ${this.size * this.labelSizeRatio}em;`;
	}

	public get getClearButtonDynamicStyles(): string {
		return `font-size: ${this.size * this.clearBtnSizeRatio}em;`;
	}

	public get isTouched(): boolean {
		return !!this.inputFormControl.value;
	}

	public onChange = (input: string | null): void => {
	};

	public onTouched = (): void => {
	};

	writeValue(input: string | null): void {
		this.inputFormControl.setValue(input);
		this.onChange(input);
	}

	registerOnChange(fn: any): void {
		this.onChange = fn;
	}

	registerOnTouched(fn: any): void {
		this.onTouched = fn;
	}

	setDisabledState?(isDisabled: boolean): void {
		isDisabled ? this.inputFormControl.disable() : this.inputFormControl.enable();
	}

	public onKeyUp(): void {
		this.writeValue(this.inputFormControl.value);
	}
}
