import { Injectable } from '@angular/core';
import { User } from '../../../models/user/User';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class UserService {

  constructor(private http: HttpClient) {}

  getUser(id: number){
    return this.http.get<User>('api/user/' + id);
  }

  deactivate(id: number){
    return this.http.put('api/user/deactivate/' + id, null);
  }

  updateImage(userId: number, form: FormData){
    return this.http.put('api/user/upload-image/' + userId, form);
  }

  update(userId: number, tagIds: number[], description: string){
    return this.http.put('api/user/' + userId, {
      description: description,
      tagIds: tagIds
    });
  }

  like(userId: number, likeBy: number){
    return this.http.put('api/user/' + userId + '/likes/' + likeBy, null);
  }

  unlike(userId: number, likeBy: number){
    return this.http.delete('api/user/' + userId + '/likes/' + likeBy);
  }

  search(searchTerm: string) {
    return this.http.get<User[]>(`api/user/search?searchTerm=` + searchTerm);
  }
}
