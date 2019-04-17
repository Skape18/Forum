import { Component, OnInit, DoCheck } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ThreadService } from '../../../services/thread/thread.service';
import { AuthenticationService } from '../../../services/authentication/authentication.service';
import { Thread } from '../../../models/thread/Thread';
import { Post } from '../../../models/post/Post';
import { SignedInUser } from '../../../models/user/SignedInUser';
import { RoleCheckService } from '../../../services/user/roleCheck/role-check.service';
import { PostService } from '../../../services/post/post.service';
import { first, map } from 'rxjs/operators';


@Component({
  selector: 'app-post-listing',
  templateUrl: './post-listing.component.html',
  styleUrls: ['./post-listing.component.css']
})
export class PostListingComponent implements OnInit{

  thread: Thread;
  posts: Post[];
  currentUser: SignedInUser;
  isCurrentUserAdmin: boolean;


  constructor(private threadService: ThreadService, private postService: PostService, private authenticationService: AuthenticationService,
    private activeRoute: ActivatedRoute, private roleCheckService: RoleCheckService) {


  }

  ngOnInit() {
    this.authenticationService.currentUser.subscribe(x => {
      this.currentUser = x;
      this.checkAdmin();
    });

    this.activeRoute.params.subscribe(params => {
      this.threadService.getThread(params.threadId).subscribe(thread => this.thread = thread);
      this.postService.getThreadPosts(params.threadId).subscribe(posts => this.posts = posts);
    });
  }

  deactivateThread(id: number){
    this.threadService.deactivate(id).subscribe(res => this.ngOnInit());
  }

  checkAdmin() {
    if (this.currentUser)
      this.roleCheckService.isAdminByUsername(this.currentUser.userName).pipe(first()).subscribe(res => {
        this.isCurrentUserAdmin = res;
      });
    else
      this.isCurrentUserAdmin = false;
  }

  deletePost(id: number){
    this.postService.deletePost(id).subscribe(res => this.ngOnInit());
  }

}
