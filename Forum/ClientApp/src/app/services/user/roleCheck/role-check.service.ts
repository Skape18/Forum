import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoleCheckService {

  isAdmin: boolean;
  constructor(private http: HttpClient) {}
 

  isAdminByUsername(userId: number){
      return this.http.get<boolean>('api/account/is-admin?userId=' + userId);
  }
}
