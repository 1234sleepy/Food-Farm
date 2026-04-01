import { Injectable } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { UserModel } from '../../models/UserModel';
import { UserAuth } from '../../models/userAuth';
import { BehaviorSubject, map, tap } from 'rxjs';
import { AuthApiService } from '../api/auth.api.service';

@Injectable({
  providedIn: 'root',
})
export class AuthStoreService {
  constructor(private readonly api: AuthApiService) {}
  //#TODO: Ask where we store credentials
  private currentUserSource = new BehaviorSubject<UserAuth | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  login(user: UserModel) {
    return this.api
      .login(user)
      .pipe(tap((usr) => this.currentUserSource.next(usr)));
  }

  check() {
    return this.api
      .check()
      .pipe(tap((usr) => this.currentUserSource.next(usr)));
  }

  logout() {
    return this.api.logout().pipe(tap(() => this.currentUserSource.next(null)));
  }

  getAuthState() {
    if (this.currentUserSource.value) {
      return this.currentUser$;
    } else {
      return this.check();
    }
  }
}
