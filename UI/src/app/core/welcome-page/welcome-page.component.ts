import { Component } from '@angular/core';
import {HeaderComponent} from "../../shared/components/header/header.component";
import {NgOptimizedImage} from "@angular/common";
import {TextColorReactDirective} from "../../shared/directives/text-color-react.directive";
import {BackgroundColorReactDirective} from "../../shared/directives/background-color-react.directive";
import {RouterLink} from "@angular/router";

@Component({
  selector: 'app-welcome-page',
  standalone: true,
  imports: [HeaderComponent, NgOptimizedImage, TextColorReactDirective, BackgroundColorReactDirective, RouterLink],
  templateUrl: './welcome-page.component.html',
  styleUrl: './welcome-page.component.css'
})
export class WelcomePageComponent {

}
