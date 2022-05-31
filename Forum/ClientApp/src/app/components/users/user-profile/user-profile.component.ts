import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user/user/user.service';
import { AuthenticationService } from '../../../services/authentication/authentication.service';
import { RoleCheckService } from '../../../services/user/roleCheck/role-check.service';
import { SignedInUser } from '../../../models/user/SignedInUser';
import { User } from '../../../models/user/User';
import { ActivatedRoute, Router } from '@angular/router';
import { first, flatMap } from 'rxjs/operators';
import { FormGroup, FormControl } from '@angular/forms';
import { Tag } from '../../../models/tag/Tag';
import { TagService } from 'src/app/services/tags/tag.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  currentUser: SignedInUser;
  tags: Tag[];
  isCurrentUserAdmin: boolean;
  isAdmin: boolean;
  user: User;
  userForm: FormGroup;

  constructor(
    private userService: UserService,
    private authenticationService: AuthenticationService,
    private roleCheckService: RoleCheckService,
    private tagService: TagService,
    private activeRoute: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit() {
    this.authenticationService.currentUser.subscribe(x => {
      this.currentUser = x;
      this.checkAdmin();
    });

    this.activeRoute.params.pipe(
      flatMap(params => this.userService.getUser(params.id))
    ).subscribe(user => {
      this.user = user;
      this.roleCheckService.isAdminByUsername(user.id).subscribe(isAdmin => this.isAdmin = isAdmin)
    });

    this.tagService.getAll().subscribe(tags => this.tags = tags);
    this.userForm = new FormGroup({
      userImage: new FormControl(null)
    }, { updateOn: 'submit' });
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
      this.roleCheckService.isAdminByUsername(this.currentUser.id).pipe(first()).subscribe(res => this.isCurrentUserAdmin = res);
    else
      this.isCurrentUserAdmin = false;
  }


  deactivate(id: number) {
    this.userService.deactivate(id).subscribe(res => this.ngOnInit());
  }

  //Image uploading
  fileChange(files: FileList) {
    if (files && files[0].size > 0) {
      this.userForm.patchValue({
        userImage: files[0]
      });
    }
  }

  onSubmit() {
    if (this.userForm.valid) {
      this.userService.updateImage(this.currentUser.id, this.prepareSaveUser()).subscribe();
      this.router.navigate(['/'])
    }
  }

  prepareSaveUser(): FormData {
    const formModel = this.userForm.value;

    let formData = new FormData();
    formData.append("userImage", formModel.userImage);

    return formData;
  }
}



