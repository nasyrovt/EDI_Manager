import { Component } from '@angular/core';
import { SwitchTables } from './SwitchTables';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'edi-manager-api-angular13';

  activators: Map<number, boolean> = new Map([
    [1, false], //activateFeeds
    [2, false], //activateClients
    [3, false], //activateDevelopers
    [4, false], //activateCarriers
    [5, false], //activateFTPAccounts
    [6, false]  //activateSSHKeys
  ]);

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
}
