import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { AuthenticationService } from '../services/authentication/authentication.service';
import { RoleCheckService } from '../services/user/roleCheck/role-check.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(
      private router: Router,
      private authenticationService: AuthenticationService,
      private roleCheckService: RoleCheckService
  ) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
      const currentUser = this.authenticationService.currentUserValue;
      if (currentUser) {
          // check if route is restricted by role
          if (this.roleCheckService.isAdminByUsername(currentUser.userName)) {
              this.router.navigate(['/']);
              return false;
          }
 
          // authorised so return true 
          return true;
      }

      // not logged in so redirect to login page with the return url
      this.router.navigate(['/login'], { queryParams: { returnUrl: state.url }});
      return false;
  }
}
