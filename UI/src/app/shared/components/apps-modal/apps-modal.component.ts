import { Component, EventEmitter, Input, OnInit } from '@angular/core';
import { NgClass } from '@angular/common';

@Component({
	selector: 'u-apps-modal',
	standalone: true,
	imports: [NgClass],
	templateUrl: './apps-modal.component.html',
	styleUrl: './apps-modal.component.css'
})
export class AppsModalComponent implements OnInit {
	@Input() showAllAppsEmitter: EventEmitter<any>;
	@Input() sectionElementRef: HTMLElement;
	public isVisible: boolean = false;

	ngOnInit(): void {
		this.showAllAppsEmitter.subscribe((): boolean => this.isVisible = true);
		this.sectionElementRef.addEventListener('click', (): boolean => this.isVisible = false);
	}
}
