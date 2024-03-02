import { Component } from '@angular/core';
import {HeaderComponent} from "../../shared/components/header/header.component";
import {NgOptimizedImage} from "@angular/common";
import {TextColorReactDirective} from "../../shared/directives/text-color-react.directive";

@Component({
  selector: 'app-welcome-page',
  standalone: true,
  imports: [HeaderComponent, NgOptimizedImage, TextColorReactDirective],
  templateUrl: './welcome-page.component.html',
  styleUrl: './welcome-page.component.css'
})
export class WelcomePageComponent {

}
