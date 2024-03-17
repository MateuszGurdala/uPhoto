import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { inject } from '@angular/core';

export const authGuard: CanActivateFn = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean => {
	const authService: any = inject(AuthService);
	const router: any = inject(Router);

	const targetRequiresSession: boolean = state.url.includes('app');
	const hasActiveSession: boolean = authService.isSessionValid();

	if (targetRequiresSession && !hasActiveSession) {
		void router.navigate(['/sign-in']);
		return false;
	} else if (!targetRequiresSession && hasActiveSession) {
		void router.navigate(['/app', 'home']);
		return false;
	}

	return true;
};
