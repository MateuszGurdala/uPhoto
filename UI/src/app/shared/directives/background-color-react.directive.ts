import { Directive, ElementRef, Input, OnChanges, SimpleChanges } from '@angular/core';

@Directive({
	selector: '[uBackgroundColorReact]',
	standalone: true
})
export class BackgroundColorReactDirective implements OnChanges {
	@Input() disabled: boolean = false;

	constructor(private element: ElementRef) {
		this.element.nativeElement.classList.add('u-background-react');
	}

	ngOnChanges(changes: SimpleChanges): void {
		this.disabled ? this.disable() : this.enable();
	}

	private enable(): void {
		this.element.nativeElement.classList.remove('u-background-disabled');
		this.element.nativeElement.classList.add('u-background-react');
	}

	private disable(): void {
		this.element.nativeElement.classList.remove('u-background-react');
		this.element.nativeElement.classList.add('u-background-disabled');
	}
}
