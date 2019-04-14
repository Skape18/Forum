import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../services/authentication/authentication.service'
import { SignedInUser } from '../../models/user/SignedInUser';
import { RoleCheckService } from '../../services/user/roleCheck/role-check.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
    currentUser: SignedInUser;
    isAdmin: boolean;

    constructor(
        private router: Router,
        private authenticationService: AuthenticationService,
        private roleCheckService: RoleCheckService
    ) {
        this.roleCheckService.isAdmin.subscribe(x => this.isAdmin = x);
       
        this.authenticationService.currentUser.subscribe(x => {
            this.currentUser = x;
            if (this.currentUser)
                this.roleCheckService.isAdminByUsername(this.currentUser.userName);
        });

    }

    logout() {
        this.authenticationService.logout();
        this.router.navigate(['/login']);
    }
}
