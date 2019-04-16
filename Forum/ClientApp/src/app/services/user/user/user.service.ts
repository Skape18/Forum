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
}
