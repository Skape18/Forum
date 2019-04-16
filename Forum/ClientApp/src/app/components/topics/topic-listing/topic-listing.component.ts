import { Component, OnInit } from '@angular/core';
import { TopicService } from '../../../services/topic/topic.service';
import { Topic } from '../../../models/topic/Topic';
import { AuthenticationService } from '../../../services/authentication/authentication.service';
import { SignedInUser } from '../../../models/user/SignedInUser';

@Component({
  selector: 'app-topic-listing',
  templateUrl: './topic-listing.component.html',
  styleUrls: ['./topic-listing.component.css']
})
export class TopicListingComponent implements OnInit {

  topics: Topic[];
  currentUser: SignedInUser;

  constructor(private topicService: TopicService, private authenticationService: AuthenticationService) {
  }

  ngOnInit() {
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    this.topicService.getAllTopics().subscribe(topics => {
      this.topics = topics;
    });
  }



}
