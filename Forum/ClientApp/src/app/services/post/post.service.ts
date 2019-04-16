import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Post } from '../../models/post/Post';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private http: HttpClient) { }

  
  getThreadPosts(threadId: number){
    return this.http.get<Post[]>('api/threads/' + threadId + '/posts');
  }
}
