import { Component, OnInit, DoCheck } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../services/authentication/authentication.service'
import { SignedInUser } from '../../models/user/SignedInUser';
import { RoleCheckService } from '../../services/user/roleCheck/role-check.service';
import { first } from 'rxjs/operators';

@Component({
    selector: 'app-nav-menu',
    templateUrl: './nav-menu.component.html',
    styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
    currentUser: SignedInUser;
    isAdmin: boolean;

    constructor(
        private router: Router,
        private authenticationService: AuthenticationService,
        private roleCheckService: RoleCheckService
    ) {

    }

    ngOnInit() {
        this.authenticationService.currentUser.subscribe(x => {
            this.currentUser = x;
            this.checkAdmin();
        });
    }

    checkAdmin() {
        if (this.currentUser != null)
            this.roleCheckService.isAdminByUsername(this.currentUser.id).pipe(first()).subscribe(res => this.isAdmin = res);
    }

    logout() {
        this.authenticationService.logout();
        this.router.navigate(['/login']);
    }
}
