import { EnvironmentProviders } from '@angular/core';
import { provideRouter, Routes } from '@angular/router';
import { authGuard } from '../../shared/guards/auth.guard';
import { WelcomePageComponent } from '../pages/welcome-page/welcome-page.component';
import { SignInPageComponent } from '../pages/sign-in-page/sign-in-page.component';
import { AppRootComponent } from '../../shared/components/app-root/app-root.component';
import { HomePageComponent } from '../pages/home-page/home-page.component';
import { PhotoPageComponent } from '../pages/photo-page/photo-page.component';

const routes: Routes = [
	{
		path: '', canActivateChild: [authGuard], children: [
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
		]
	}
];


export const RouterProvider: EnvironmentProviders = provideRouter(routes);
