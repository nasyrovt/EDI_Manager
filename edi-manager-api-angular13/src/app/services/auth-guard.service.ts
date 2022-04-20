import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  usersList$!: Observable<any[]>;
  usersList: any = [];
  usersMap: Map<string, string> = new Map();

  readonly APIUrl = "https://localhost:7255/api";

  constructor(private jwtHelper: JwtHelperService, private router: Router, private http: HttpClient) {
    this.usersList$ = this.getUsersList();
    this.refreshUsersMap();
  }


  canActivate() {
    const token = localStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    this.router.navigate(["/login"]);
    return false;
  }

  refreshUsersMap() {
    this.getUsersList().subscribe(data => {
      this.usersList = data;
      for (let i = 0; i < data.length; i++) {
        this.usersMap.set(this.usersList[i].userName, this.usersList[i].role);
      }
    });
  }

  getUsersList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + "/users");
  }
}