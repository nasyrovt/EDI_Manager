import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.scss']
})
export class HomePageComponent implements OnInit {

  devTabActive = false;
  adminTabActive = false;
  currentUser: string | null = "";

  activators: Map<number, boolean> = new Map([
    [1, false], //activateFeeds
    [2, false], //activateClients
    [3, false], //activateDevelopers
    [4, false], //activateCarriers
    [5, false], //activateFTPAccounts
    [6, false],  //activatePlatforms
    [7, false]  //activateSSHKeys
  ]);

  constructor(private router: Router, private jwtHelper: JwtHelperService) { }

  ngOnInit(): void {
    this.currentUser = localStorage.getItem("CurrentUser");
  }

  public setAllFalse() {
    this.activators.forEach(
      (value: boolean, key: number) => {
        this.activators.set(key, false)
      }
    );
  }

  public setBool(activator: number, value: boolean) {
    this.activators.set(activator, true);
  }

  public getFeedsActivator(activator: number): boolean | undefined {
    return this.activators.get(activator);
  }

  public getDevTabActivate(): boolean {
    return this.devTabActive;
  }

  public getAdminTabActivate(): boolean {
    return this.adminTabActive;
  }

  public setAdminTabActivate(value: boolean): void {
    this.adminTabActive = value;
  }
  public setDevTabActivate(value: boolean): void {
    this.devTabActive = value;
  }

  logout() {
    localStorage.removeItem('jwt');
    localStorage.removeItem('CurrentUserRole');
    localStorage.removeItem('CurrentUser');
    this.router.navigate(['login']);
  }



  public changeBackgroundColor(boxId: string): void {
    const box = document.getElementById(boxId);
    if (box) {
      box.style.backgroundColor = 'white';
    }
  }
}
