import { Directive, ElementRef, HostListener, Input, OnInit, Renderer2 } from '@angular/core';

@Directive({
	selector: '[uTextColorReact]',
	standalone: true
})
export class TextColorReactDirective implements OnInit {
	@Input() textBaseColor: string = '--accent';
	@Input() textHoverColor: string = '--accent-tint';
	@Input() textActiveColor: string = '--accent-shade';

	constructor(private element: ElementRef, private renderer: Renderer2) {
	}

	ngOnInit(): void {
		this.renderer.setStyle(this.element.nativeElement, 'color', `var(${this.textBaseColor})`);
		this.renderer.setStyle(this.element.nativeElement, 'cursor', 'pointer');
	}

	@HostListener('mouseover') onMouseOver(): void {
		this.renderer.setStyle(this.element.nativeElement, 'color', `var(${this.textHoverColor})`);
	}

	@HostListener('mouseleave') onMouseLeave(): void {
		this.renderer.setStyle(this.element.nativeElement, 'color', `var(${this.textBaseColor})`);
	}

	@HostListener('mousedown') onMouseDown(): void {
		this.renderer.setStyle(this.element.nativeElement, 'color', `var(${this.textActiveColor})`);
	}

	@HostListener('mouseup') onMouseUp(): void {
		this.renderer.setStyle(this.element.nativeElement, 'color', `var(${this.textHoverColor})`);
	}
}
