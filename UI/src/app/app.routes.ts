import { Routes } from '@angular/router';
import { SignInPageComponent } from './core/sign-in-page/sign-in-page.component';
import { WelcomePageComponent } from './core/welcome-page/welcome-page.component';

export const routes: Routes = [
	{path: 'welcome', component: WelcomePageComponent, title: 'uPhoto', pathMatch: 'full'},
	{path: 'sign-in', component: SignInPageComponent, title: 'Sign In', pathMatch: 'full'},
	{path: '**', redirectTo: 'welcome'}
];
