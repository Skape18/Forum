import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Topic } from "../../models/topic/Topic";

@Injectable({
  providedIn: 'root'
})
export class TopicService {

  constructor(private http: HttpClient) { }


  getAllTopics(){
    return this.http.get<Topic[]>('api/topics');
  }
}
