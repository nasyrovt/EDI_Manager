import { Component } from '@angular/core';
import { SwitchTables } from './SwitchTables';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'edi-manager-api-angular13';

  activateFeeds: boolean = SwitchTables.activateFeeds;
  activateClients: boolean = SwitchTables.activateClients;
  activateDevelopers: boolean = SwitchTables.activateDevelopers;
  activateCarriers: boolean = SwitchTables.activateCarriers;
  activateFTPAccounts: boolean = SwitchTables.activateFTPAccounts;
  activateSSHKeys: boolean = SwitchTables.activateSSHKeys;

  activators: boolean[] = [this.activateFeeds, this.activateClients, this.activateCarriers, this.activateFTPAccounts, this.activateSSHKeys, this.activateDevelopers];

  public setAllFalse() {
    for (let i = 0; i < this.activators.length; i++) {
      this.activators[i] = false;
    }
  }

  public setBool(activator: number, value: boolean) {
    this.activators[activator] = value;
  }

  public getFeedsActivator(activator: number): boolean {
    return this.activators[activator];
  }
}
