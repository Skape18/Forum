import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoleCheckService {

  constructor(private http: HttpClient) {}

  private isAdminSubject: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public isAdmin: Observable<boolean> = this.isAdminSubject.asObservable();

  isAdminValue(){
    return this.isAdminSubject.value;
  }

  isAdminByUsername(username: string) {
      this.http.get<boolean>('api/account/isadmin?userName=' + username).subscribe(isAdm => this.isAdminSubject.next(isAdm));
      return this.isAdmin;
  }
}
