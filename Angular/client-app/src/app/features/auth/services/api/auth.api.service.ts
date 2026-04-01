import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { UserModel } from '../../models/UserModel';
import { UserAuth } from '../../models/userAuth';

@Injectable({
  providedIn: 'root',
})
export class AuthApiService {
  private baseUrl: string =
    environment.apiUrl + '/account-service/api/account/';
  constructor(private readonly httpClient: HttpClient) {}

  login(user: UserModel) {
    return this.httpClient.post<UserAuth>(this.baseUrl + 'login', user);
  }

  check() {
    return this.httpClient.get<UserAuth>(this.baseUrl + 'check');
  }

  logout() {
    return this.httpClient.delete(this.baseUrl + 'logout');
  }
}
