import { Component, OnInit } from '@angular/core';
import { TopicService } from '../../../services/topic/topic.service';
import { AuthenticationService } from '../../../services/authentication/authentication.service';
import { Topic } from '../../../models/topic/Topic';
import { Thread } from '../../../models/thread/Thread';
import { SignedInUser } from '../../../models/user/SignedInUser'
import { ActivatedRoute } from '@angular/router';
import { flatMap } from 'rxjs/operators';
import { ThreadService } from '../../../services/thread/thread.service';

@Component({
  selector: 'app-thread-listing',
  templateUrl: './thread-listing.component.html',
  styleUrls: ['./thread-listing.component.css']
})
export class ThreadListingComponent implements OnInit {

  topic: Topic;
  threads: Thread[];
  currentUser: SignedInUser;

  constructor(private topicService: TopicService, private threadService: ThreadService, private authenticationService: AuthenticationService,
    private activeRoute: ActivatedRoute) {

  }

  ngOnInit() {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);

    this.activeRoute.params.subscribe(params => {
      this.topicService.getTopic(params.topicId).subscribe(t => this.topic = t);
      this.threadService.getTopicThreads(params.topicId).subscribe(th => this.threads = th);
    });
  }

}
