import {Directive, ElementRef} from '@angular/core';

@Directive({
  selector: '[appTextColorReact]',
  standalone: true
})
export class TextColorReactDirective {
  constructor(private element: ElementRef) {
    this.element.nativeElement.classList.add('u-color-react');
  }
}
