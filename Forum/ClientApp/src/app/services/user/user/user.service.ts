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
}
