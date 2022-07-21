import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ReplaySubject } from 'rxjs';
import { User } from '../_models/user';
import { map } from'rxjs/operators';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
    baseUrl = environment.apiUrl;
    private currentUserSource = new ReplaySubject<User>(1);
    currentUser$ = this.currentUserSource.asObservable();


  constructor(private http: HttpClient) {}

  login(model: any){
    return this.http.post(this.baseUrl + 'account/login', model).pipe(
      map((response: User) => {
        const user = response;
        if (user){
          localStorage.setItem("user", JSON.stringify(user));
          this.setCurrentUser(user);
          console.log(user)
        }
      })
    )
  }

  setCurrentUser(user: User) {
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
  }


  logout(){
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }

  //later deal with reactive form, validation
  register(model: any){
    return this.http.post(this.baseUrl + "account/register", model).pipe(
      map((user:any) => {
        if (user) {
          this.setCurrentUser(user);
        }
        return user;
      })
    )
  }

}
