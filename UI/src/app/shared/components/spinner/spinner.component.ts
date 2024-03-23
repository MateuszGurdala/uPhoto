import { Component, ElementRef, OnInit } from '@angular/core';
import { NgStyle } from '@angular/common';

@Component({
	selector: 'u-spinner',
	standalone: true,
	imports: [
		NgStyle
	],
	styleUrl: './spinner.component.css',
	templateUrl: './spinner.component.html',

})
export class SpinnerComponent implements OnInit {
	private size: number; //rem

	constructor(private elementRef: ElementRef) {
	}

	public ngOnInit(): void {
		this.size = this.elementRef.nativeElement.offsetWidth * 0.1;
		this.elementRef.nativeElement.style.setProperty('--slide-dist', this.getRelativeSizeScaled(0.3));
	}

	public getRelativeSizeScaled(scale: number): string {
		return this.size * scale + 'rem';
	}
}
