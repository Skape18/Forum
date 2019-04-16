import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Thread } from '../../models/thread/Thread';

@Injectable({
  providedIn: 'root'
})
export class ThreadService {

  constructor(private http: HttpClient) { }

  getTopicThreads(topicId: number){
    return this.http.get<Thread[]>('api/topics/' + topicId + '/threads');
  }

  getThread(id: number){
    return this.http.get<Thread>('api/threads/' + id);
  }
}
