import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoleCheckService {

  isAdmin: boolean;
  constructor(private http: HttpClient) {}
 

  isAdminByUsername(username: string){
      return this.http.get<boolean>('api/account/isadmin?userName=' + username);
  }
}
