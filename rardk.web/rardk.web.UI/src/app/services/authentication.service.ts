import { HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  lsKey: string = 'discord-access-token';

  constructor() {}

  login(token: string): Observable<any> {
    if (token) {
      localStorage.setItem(this.lsKey, token);
      return of(new HttpResponse({ status: 200 }));
    }
    return of(new HttpResponse({ status: 401 }));
  }
  logout() {
    localStorage.removeItem(this.lsKey);
  }

  isUserLoggedIn(): boolean {
    return localStorage.getItem(this.lsKey) != null;
  }
}
