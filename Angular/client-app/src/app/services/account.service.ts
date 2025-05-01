import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';
import { UserModel } from '../models/UserModel';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private baseUrl: string = environment.apiUrl + '/account/';
  constructor(private httpClient: HttpClient) { }

    login(user: UserModel) {
          return this.httpClient.post<UserModel>(this.baseUrl+"login", user);
    }
}
