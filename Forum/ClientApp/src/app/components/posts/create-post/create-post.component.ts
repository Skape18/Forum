import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { Thread } from '../../../models/thread/Thread';
import { SignedInUser } from '../../../models/user/SignedInUser';
import { AuthenticationService } from '../../../services/authentication/authentication.service';
import { ThreadService } from '../../../services/thread/thread.service';
import { PostService } from '../../../services/post/post.service';
import { PostCreate } from '../../../models/post/PostCreate';
import { first } from 'rxjs/operators';


@Component({
  selector: 'app-create-post',
  templateUrl: './create-post.component.html',
  styleUrls: ['./create-post.component.css']
})
export class CreatePostComponent implements OnInit {

  postForm: FormGroup;
  currentUser: SignedInUser;
  thread: Thread;
  repliedPostId: number;
  loading = false;
  submitted = false;
  error = '';

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private activeRoute: ActivatedRoute,
    private authenticationService: AuthenticationService,
    private threadService: ThreadService,
    private postService: PostService
  ) {
  }

  ngOnInit() {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);

    this.postForm = this.formBuilder.group({
      content: ['', Validators.required]
    });

    this.activeRoute.params.subscribe(params => {
      this.threadService.getThread(params['threadId']).subscribe(thread => this.thread = thread);
      this.repliedPostId = params['repliedPostId'];
    });
  }

  // convenience getter for easy access to form fields
  get formControls() { return this.postForm.controls; }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.postForm.invalid) {
      return;
    }

    this.loading = true;
    let postCreate = new PostCreate(this.formControls.content.value, this.currentUser.id, this.thread.id, this.repliedPostId);

    this.postService.createPost(postCreate)
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigate(['/posts', this.thread.id]);
        },
        error => {
          this.error = error;
          this.loading = false;
        });
  }
}
