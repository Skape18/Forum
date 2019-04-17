import { Component, OnInit } from '@angular/core';
import { TopicService } from '../../../services/topic/topic.service';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-topic',
  templateUrl: './create-topic.component.html',
  styleUrls: ['./create-topic.component.css']
})
export class CreateTopicComponent implements OnInit {

  
  topicForm: FormGroup;

  constructor(private topicService: TopicService, private router: Router) { }

  ngOnInit() {

    this.topicForm = new FormGroup({
      title: new FormControl(''),
      description: new FormControl(''),
      image: new FormControl(null)
    }, { updateOn: 'submit' });
  }

   //Image uploading
   fileChange(files: FileList) {
    if (files && files[0].size > 0) {
      this.topicForm.patchValue({
        image: files[0]
      });
    }
  }

  onSubmit() {
    if (this.topicForm.valid) {
      this.topicService.createTopic(this.prepareSaveTopic()).subscribe(res =>  this.router.navigate(['/']));
    }
  }

  prepareSaveTopic(): FormData {
    const formModel = this.topicForm.value;

    let formData = new FormData();
    formData.append("image", formModel.image);
    formData.append("title", formModel.title);
    formData.append("description", formModel.description);

    return formData;
  }
}
