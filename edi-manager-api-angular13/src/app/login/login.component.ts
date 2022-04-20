import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthGuard } from '../services/auth-guard.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  invalidLogin: boolean | undefined

  constructor(private router: Router, private http: HttpClient, private users: AuthGuard) {
    this.users.refreshUsersMap();
  }

  login(form: NgForm) {
    const credentials = {
      'username': form.value.username,
      'password': form.value.password,
      'role': this.users.usersMap.get(form.value.username)
    }
    console.log(this.users.usersMap.get(form.value.username))

    this.http.post("https://localhost:7255/api/auth/login", credentials)
      .subscribe(response => {
        const token = (<any>response).token;
        localStorage.setItem("jwt", token);
        if (credentials.role && credentials.username) {
          localStorage.setItem("CurrentUser", credentials.username);
          localStorage.setItem("CurrentUserRole", credentials.role);
        }
        this.invalidLogin = false;
        this.router.navigate(["/home"]);

      }, err => {
        this.invalidLogin = true;
      })
  }

  createNewUser(form: NgForm) {
    const credentials = {
      'username': form.value.usernameSign,
      'password': form.value.passwordSign,
      'role': form.value.role
    }

    this.http.post("https://localhost:7255/api/users", credentials)
      .subscribe(response => { }, err => {
        console.log(err)
      })
  }

}
