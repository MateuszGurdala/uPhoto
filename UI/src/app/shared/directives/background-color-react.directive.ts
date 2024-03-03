import {Directive, ElementRef} from '@angular/core';

@Directive({
  selector: '[uBackgroundColorReact]',
  standalone: true
})
export class BackgroundColorReactDirective {
  constructor(private element: ElementRef) {
    this.element.nativeElement.classList.add('u-background-react');
  }

}
