import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Thread } from '../../models/thread/Thread';
import { ThreadCreate } from '../../models/thread/ThreadCreate';

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

  deactivate(id: number){
    return this.http.put('api/threads/deactivate/' + id, null);
  }

  createThread(thread: ThreadCreate) {
    return this.http.post('api/threads', thread);
  }
}
