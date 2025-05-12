import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';
import { UserModel } from '../models/UserModel';
import { UserAuth } from '../models/userAuth';
import { BehaviorSubject, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private baseUrl: string = environment.apiUrl + '/account/';
  constructor(private httpClient: HttpClient) { }
  
  private currentUserSource = new BehaviorSubject<UserAuth | null>(null);
  currentUser$ = this.currentUserSource.asObservable();


    login(user: UserModel) {
          return this.httpClient.post<UserAuth>(this.baseUrl+"login", user, { withCredentials: true }).pipe(map((usr) => {
            this.currentUserSource.next(usr);
          }));
    }

    check() {
          return this.httpClient.get<UserAuth>(this.baseUrl+"check", { withCredentials: true }).pipe(map((usr) => {
            this.currentUserSource.next(usr);
            return usr;
          }));
    }

    logout() {
          return this.httpClient.delete(this.baseUrl+"logout", { withCredentials: true }).pipe(map((usr) => {
            this.currentUserSource.next(null);
          }));;
    }

    getAuthState() {
      if(this.currentUserSource.value) {
        return this.currentUser$;
      }else{
        return this.check();
      }
    }

}
