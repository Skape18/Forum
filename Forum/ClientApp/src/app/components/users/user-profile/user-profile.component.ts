import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user/user/user.service';
import { AuthenticationService } from '../../../services/authentication/authentication.service';
import { RoleCheckService } from '../../../services/user/roleCheck/role-check.service';
import { SignedInUser } from '../../../models/user/SignedInUser';
import { User } from '../../../models/user/User';
import { ActivatedRoute, Router } from '@angular/router';
import {first, flatMap, mergeMap} from 'rxjs/operators';
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
  imageUrl;

  dropdownSettings: any = {
    singleSelection: false,
    idField: 'id',
    textField: 'name',
    enableCheckAll: false,
    itemsShowLimit: 20,
    allowSearchFilter: true
  };
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
    this.userForm = new FormGroup({
      userImage: new FormControl(null),
      tag: new FormControl([]),
      description: new FormControl('')
    }, { updateOn: 'submit' });

    this.authenticationService.currentUser.subscribe(x => {
      this.currentUser = x;
      this.checkAdmin();
    });

    this.activeRoute.params.pipe(
      flatMap(params => this.userService.getUser(params.id))
    ).subscribe(user => {
      this.user = user;
      this.userForm.patchValue({
        description: user.description,
        tag: user.tags,
      });
      this.imageUrl = user.profileImagePath;
      this.roleCheckService.isAdminByUsername(user.id).subscribe(isAdmin => this.isAdmin = isAdmin)
    });

    this.tagService.getAll().subscribe(tags =>{
      this.tags = tags;
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

  tagList(){
    return this.tags.map(t => t.name).join(', ');
  }

  //Image uploading
  fileChange(files: FileList) {
    if (files && files[0].size > 0) {
      this.userForm.patchValue({
        userImage: files[0]
      });
      const reader = new FileReader();
      reader.readAsDataURL(files[0]);
      reader.onload = (_event) => {
        this.imageUrl = reader.result;
      }
    }
  }

  onSubmit() {
    if (this.userForm.valid) {
      if (this.userForm.value.userImage){
        this.userService.updateImage(this.currentUser.id, this.prepareSaveUser()).pipe(
          flatMap(res => this.userService.update(
            this.currentUser.id,
            this.userForm.value.tag.map(t => t.id),
            this.userForm.value.description))
        ).subscribe(res => window.location.reload());
      }
      else {
        this.userService.update(
          this.currentUser.id,
          this.userForm.value.tag.map(t => t.id),
          this.userForm.value.description)
          .subscribe(r => window.location.reload());
      }
    }
  }

  prepareSaveUser(): FormData {
    const formModel = this.userForm.value;

    let formData = new FormData();
    formData.append("userImage", formModel.userImage);

    return formData;
  }
}
