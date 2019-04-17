import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthenticationService } from '../../../services/authentication/authentication.service';
import { Router, ActivatedRoute } from '@angular/router';
import { first } from 'rxjs/operators';
import { SignedInUser } from '../../../models/user/SignedInUser';
import { ThreadService } from '../../../services/thread/thread.service';
import { ThreadCreate } from '../../../models/thread/ThreadCreate';
import { TopicService } from '../../../services/topic/topic.service';
import { Topic } from '../../../models/topic/Topic';

@Component({
  selector: 'app-create-thread',
  templateUrl: './create-thread.component.html',
  styleUrls: ['./create-thread.component.css']
})
export class CreateThreadComponent implements OnInit {

    threadForm: FormGroup;
    currentUser: SignedInUser;   
    topic: Topic;
    loading = false;
    submitted = false;
    error = '';

    constructor(
        private formBuilder: FormBuilder,
        private router: Router,
        private activeRoute: ActivatedRoute,
        private authenticationService: AuthenticationService,
        private threadService: ThreadService,
        private topicService: TopicService
    ) { 
    }

    ngOnInit() {
        this.authenticationService.currentUser.subscribe(x => this.currentUser = x);

        this.threadForm = this.formBuilder.group({
            title: ['', Validators.required],
            content: ['', Validators.required]
        });

        this.activeRoute.params.subscribe(params => {
          this.topicService.getTopic(params['topicId']).subscribe(topic => this.topic = topic)
        });
    }

    // convenience getter for easy access to form fields
    get formControls() { return this.threadForm.controls; }

    onSubmit() {
        this.submitted = true;

        // stop here if form is invalid
        if (this.threadForm.invalid) {
            return;
        }

        this.loading = true;
        let threadCreate = new ThreadCreate(this.formControls.title.value, this.formControls.content.value, this.currentUser.id, this.topic.id);

        this.threadService.createThread(threadCreate)
            .pipe(first())
            .subscribe(
                data => {
                    this.router.navigate(['/threads', this.topic.id]);
                },
                error => {
                    this.error = error;
                    this.loading = false;
                });
    }

}
