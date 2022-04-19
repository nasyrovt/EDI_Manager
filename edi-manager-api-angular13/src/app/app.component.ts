import { Router } from '@angular/router';
import { Component } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'edi-manager-api-angular13';

  constructor(private router: Router, private jwtHelper: JwtHelperService) { }

  isUserAutheticated() {
    const token: string | null = localStorage.getItem('jwt');
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true
    }
    else {
      return false
    }
  }

  logOut() {
    localStorage.removeItem('jwt')
  }
}
