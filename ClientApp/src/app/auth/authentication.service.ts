import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Repository } from '../models/repository';
import { Observable } from 'rxjs';
import { of } from "rxjs";
import { map,catchError } from 'rxjs/operators';

@Injectable()
export class AuthenticationService {
  constructor(private repo: Repository, private router: Router) { }
  authenticated: boolean= false;
  name: string;
  password: string;
  callbackUrl: string;
  login(): Observable<boolean> {
    this.authenticated = false;
    return this.repo.login(this.name, this.password).pipe(
      map(response => {
        alert(response);
        if (response) {
         
          this.authenticated = true;
          this.password = null;
          this.router.navigateByUrl(this.callbackUrl || "admin/upload");
        }
         return this.authenticated;
      }),
      catchError(e => {
        alert(e);
        this.authenticated = false;
        return of(false);
      })
      );
  }

  logout() {
    this.authenticated = false;
    this.name = "";
    this.password = "";
    this.repo.logout();
    this.router.navigateByUrl("/admin/login");
  }

}
