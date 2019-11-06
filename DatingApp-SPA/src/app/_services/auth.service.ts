import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { Token } from '@angular/compiler';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from '../../environments/environment';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = environment.apiUrl + 'auth/';
  JwtHelper = new JwtHelperService();
  decodedToken: any;
  currentUser: User;
  photoUrl = new BehaviorSubject<string>('../../assets/user.jpg');
  currentPhotoUrl = this.photoUrl.asObservable();

  changeMemberPhoto(photoUrl: string) {
    this.photoUrl.next(photoUrl);
  }

  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http
      .post(this.baseUrl + 'login', model)
      .pipe(
        map((response: any) => {

          const user = response;
          if (user) {
            localStorage.setItem('token', user.token);
            // show me this section on video
            // get item takes on argument
            // set item takes to argument (key, data)
            localStorage.setItem('user', JSON.stringify(user.user));
            this.decodedToken = this.JwtHelper.decodeToken(user.token);
            this.currentUser = user.user;
            this.changeMemberPhoto(this.currentUser.photoUrl);
          }
        })
      );
  }
  register(user: User) {
    return this.http.post(this.baseUrl + 'register', user);
  }
  loggedIn() {
    const token = localStorage.getItem('token');
    if (token) {
      const isExpired = this.JwtHelper.isTokenExpired(token);
      return !isExpired;
    } else {
      return false;
    }
  }

}
