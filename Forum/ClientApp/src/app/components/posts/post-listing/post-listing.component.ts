import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ThreadService } from '../../../services/thread/thread.service';
import { AuthenticationService } from '../../../services/authentication/authentication.service';
import { Thread } from '../../../models/thread/Thread';
import { Post } from '../../../models/post/Post';
import { SignedInUser } from '../../../models/user/SignedInUser';
import { RoleCheckService } from '../../../services/user/roleCheck/role-check.service';
import { PostService } from '../../../services/post/post.service';


@Component({
  selector: 'app-post-listing',
  templateUrl: './post-listing.component.html',
  styleUrls: ['./post-listing.component.css']
})
export class PostListingComponent implements OnInit {

  thread: Thread;
  posts: Post[];
  currentUser: SignedInUser;


  constructor(private threadService: ThreadService, private postService: PostService, private authenticationService: AuthenticationService,
    private activeRoute: ActivatedRoute, private roleCheck: RoleCheckService) {


  }

  ngOnInit() {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);

    this.activeRoute.params.subscribe(params => {
      this.threadService.getThread(params.threadId).subscribe(thread => this.thread = thread);
      this.postService.getThreadPosts(params.threadId).subscribe(posts => this.posts = posts);
    });
  }

  isUserAdmin(userName: string) {
    this.roleCheck.isAdminByUsername(userName);
  }


}
