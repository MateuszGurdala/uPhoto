import { Directive, ElementRef, Renderer2 } from '@angular/core';

@Directive({
	selector: '[uIcon]',
	standalone: true
})
export class IconDirective {
	constructor(private element: ElementRef, private renderer: Renderer2) {
		this.renderer.addClass(this.element.nativeElement, 'material-symbols-outlined');
	}

}
