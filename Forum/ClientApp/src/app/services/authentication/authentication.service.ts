import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { SignedInUser } from '../../models/user/SignedInUser';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private currentUserSubject: BehaviorSubject<SignedInUser>;
  public currentUser: Observable<SignedInUser>;

  constructor(private http: HttpClient) {
      this.currentUserSubject = new BehaviorSubject<SignedInUser>(JSON.parse(localStorage.getItem('currentUser')));
      this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue(): SignedInUser {
      return this.currentUserSubject.value;
  }

  login(username: string, password: string) {
      return this.http.post<any>('api/account/login', { username, password })
          .pipe(map(user => {
              // login successful if there's a jwt token in the response
              this.addUserToLocalStorage(user);
              return user;
          }));
  }

  logout() {
      // remove user from local storage to log user out
      localStorage.removeItem('currentUser');
      this.currentUserSubject.next(null);
  }

  register(username: string, password: string, email: string, profileImagePath?: string){
        return this.http.post<any>('api/account/registration', { username, password, email, profileImagePath })
        .pipe(map(user => {
            // login successful if there's a jwt token in the response
            this.addUserToLocalStorage(user);
            return user;
        }));
  }

  private addUserToLocalStorage(signedInUser: SignedInUser){
        if (signedInUser && signedInUser.token) {
            localStorage.setItem('currentUser', JSON.stringify(signedInUser));
            this.currentUserSubject.next(signedInUser);
        }
  }
}