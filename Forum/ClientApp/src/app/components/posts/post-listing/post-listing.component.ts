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
import { UserService } from '../../../services/user/user/user.service';


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
    private activeRoute: ActivatedRoute, private roleCheckService: RoleCheckService, private userService: UserService) {


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
      this.roleCheckService.isAdminByUsername(this.currentUser.id).pipe(first()).subscribe(res => {
        this.isCurrentUserAdmin = res;
      });
    else
      this.isCurrentUserAdmin = false;
  }

  deletePost(id: number){
    this.postService.deletePost(id).subscribe(res => this.ngOnInit());
  }

  isLikedUser(userId: number){
    return this.currentUser.likedToIds.includes(userId);
  }

  isDislikedUser(userId: number) {
    return this.currentUser.dislikedToIds.includes(userId);  
  }

  like(userId: number){
    this.userService.like(userId, this.currentUser.id).subscribe(
      r => {
        let rating = 0;
        if (this.isDislikedUser(userId)){
          rating = 2;
          this.currentUser.dislikedToIds = this.currentUser.dislikedToIds.filter(id => id !== userId);
          this.currentUser.likedToIds.push(userId);
        }
        else if (this.isLikedUser(userId)){
          this.currentUser.likedToIds = this.currentUser.likedToIds.filter(id => id !== userId);
          rating = -1;
        }
        else {
          rating = 1;
          this.currentUser.likedToIds.push(userId); 
        }

        
        this.addRatingToUser(userId, rating);
        this.authenticationService.addUserToLocalStorage(this.currentUser);
      }
    );
  }

  unlike(userId: number){
    this.userService.unlike(userId, this.currentUser.id).subscribe(
      r => {
        let rating = 0;
        if (this.isLikedUser(userId)){
          rating = -2;
          this.currentUser.likedToIds = this.currentUser.likedToIds.filter(id => id !== userId);
          this.currentUser.dislikedToIds.push(userId);
        }
        else if (this.isDislikedUser(userId)){
          this.currentUser.dislikedToIds = this.currentUser.dislikedToIds.filter(id => id !== userId);
          rating = 1;
        }
        else {
          rating = -1;
          this.currentUser.dislikedToIds.push(userId); 
        }

        this.addRatingToUser(userId, rating);
        this.authenticationService.addUserToLocalStorage(this.currentUser);
      }
    )
  }

  private addRatingToUser(userId: number, rating: number){
    for (const post of this.posts){
      if (post.userProfile.id === userId){
        post.userProfile.rating += rating;
      }
    }
    if (this.thread.userProfile.id === userId){
      this.thread.userProfile.rating += rating;
    }
  }
}
