import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user/user/user.service';
import { AuthenticationService } from '../../../services/authentication/authentication.service';
import { RoleCheckService } from '../../../services/user/roleCheck/role-check.service';
import { SignedInUser } from '../../../models/user/SignedInUser';
import { User } from '../../../models/user/User';
import { ActivatedRoute } from '@angular/router';
import { first, flatMap } from 'rxjs/operators';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  currentUser: SignedInUser;
  isCurrentUserAdmin: boolean;
  isAdmin: boolean;
  user: User;

  constructor(
    private userService: UserService,
    private authenticationService: AuthenticationService,
    private roleCheckService: RoleCheckService,
    private activeRoute: ActivatedRoute
  ) {

  }

  ngOnInit() {
    this.authenticationService.currentUser.subscribe(x => {
      this.currentUser = x;
      this.checkAdmin();
    });

    this.activeRoute.params.pipe(
      flatMap(params => this.userService.getUser(params.id))
    ).subscribe(user => {
      this.user = user;
      this.roleCheckService.isAdminByUsername(user.userName).subscribe(isAdmin => this.isAdmin = isAdmin)
    });
  }

  get isSameUser(): boolean {
    if (this.currentUser) {
      if (this.currentUser.userName === this.user.userName) {
        return true;
      }
    }
    return false;
  }

  checkAdmin() {
    if (this.currentUser)
      this.roleCheckService.isAdminByUsername(this.currentUser.userName).pipe(first()).subscribe(res => this.isCurrentUserAdmin = res);
    else
      this.isCurrentUserAdmin = false;
  }

}



