import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Post } from '../../models/post/Post';
import { PostCreate } from '../../models/post/PostCreate';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private http: HttpClient) { }

  
  getThreadPosts(threadId: number){
    return this.http.get<Post[]>('api/threads/' + threadId + '/posts');
  }

  createPost(post: PostCreate){
    return this.http.post('api/posts', post);
  }

  deletePost(postId: number){
    return this.http.delete('api/posts/'+ postId);
  }
}
