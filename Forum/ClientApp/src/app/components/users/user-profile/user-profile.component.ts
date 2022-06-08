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
import { TagService } from '../../../services/tags/tag.service';
import { forkJoin } from 'rxjs';

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

  dropdownSettings: any = {};
  selectedTags = [];

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

    this.dropdownSettings = {
      singleSelection: false,
      idField: 'id',
      textField: 'name',
      enableCheckAll: false,
      itemsShowLimit: 20,
      allowSearchFilter: true
  };
    this.tagService.getAll().subscribe(tags => this.tags = tags);
    this.userForm = new FormGroup({
      userImage: new FormControl(null),
      tag: new FormControl(this.tags),
      description: new FormControl(this.user.description)
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

  get userDescription(): string {
    if (this.user.description == null || this.user.description == undefined){
      return "";
    }
    return this.user.description;
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
      forkJoin(
        [
          this.userService.updateImage(this.currentUser.id, this.prepareSaveUser()),
          this.userService.updateTags(this.currentUser.id, this.userForm.value.tag.map(t => t.id)),
          this.userService.updateDescription(this.currentUser.id, this.user.description)
        ]
      )
      .subscribe(r => this.router.navigate(['/']));      
    }
  }

  prepareSaveUser(): FormData {
    const formModel = this.userForm.value;

    let formData = new FormData();
    formData.append("userImage", formModel.userImage);

    return formData;
  }
}
