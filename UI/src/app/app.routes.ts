import {Routes} from '@angular/router';
import {WelcomePageComponent} from "./core/welcome-page/welcome-page.component";

export const routes: Routes = [
  {path: 'welcome', component: WelcomePageComponent, title: 'uPhoto', pathMatch: "full"},
  {path: '**', redirectTo: 'welcome'}
];
