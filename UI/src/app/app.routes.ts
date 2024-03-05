import { Routes } from '@angular/router';
import { SignInPageComponent } from './core/sign-in-page/sign-in-page.component';
import { WelcomePageComponent } from './core/welcome-page/welcome-page.component';
import { AppRootComponent } from './shared/components/app-root/app-root.component';
import { HomePageComponent } from './core/home-page/home-page.component';
import { PhotoPageComponent } from './core/photo-page/photo-page.component';

export const routes: Routes = [
	{path: 'welcome', component: WelcomePageComponent, title: 'uPhoto'},
	{path: 'sign-in', component: SignInPageComponent, title: 'Sign In'},
	{
		path: 'app', component: AppRootComponent, children: [
			{path: 'home', component: HomePageComponent, title: 'Home Page'},
			{path: 'photos', component: PhotoPageComponent, title: 'Photos'},
			{path: '**', redirectTo: 'home'}
		]
	},
	{path: '**', redirectTo: 'welcome'}
];
