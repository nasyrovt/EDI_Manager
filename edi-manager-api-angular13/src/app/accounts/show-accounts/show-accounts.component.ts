import { FtpserverApiService } from './../../services/ftpserver-api.service';
import { FileMimesApiService } from '../../services/file-mimes-api.service';
import { Component, OnInit, PipeTransform } from '@angular/core';
import { FeedsApiService } from 'src/app/services/feeds-api.service';
import { ClientsApiService } from 'src/app/services/clients-api.service';
import { DevelopersApiService } from 'src/app/services/developers-api.service';
import { FilesService } from 'src/app/services/files-api.service';
import { map, Observable, startWith } from 'rxjs';
import { FormControl } from '@angular/forms';
import { DecimalPipe } from '@angular/common';

@Component({
  selector: 'app-show-accounts',
  templateUrl: './show-accounts.component.html',
  styleUrls: ['./show-accounts.component.scss'],
  providers: [DecimalPipe]
})
export class ShowAccountsComponent implements OnInit {

  modalTitle: string = "";
  activateAddEditAccountsComponent: boolean = false;
  account: any;

  orderHeader: String = '';
  isDescOrder: boolean = true;
  filter = new FormControl('');
  accounts: any = [];
  accounts$: Observable<any[]>;


  constructor(public feedsService: FeedsApiService, public fileTypesService: FileMimesApiService,
    public clientsService: ClientsApiService, public developersService: DevelopersApiService,
    public filesService: FilesService, public accountsService: FtpserverApiService, public pipe: DecimalPipe) {
    this.accounts$ = accountsService.serversList$;
  }

  ngOnInit(): void {
    this.accounts$.subscribe(data => {
      this.accounts = data;
      this.accounts$ = this.filter.valueChanges.pipe(
        startWith(''),
        map(text => this.search(data, text, this.pipe))
      );
    })
  }

  search(accounts: any[], text: string, pipe: PipeTransform): any[] {
    return accounts.filter(account => {
      const term = text.toLowerCase();
      return account.ftpHost.toLowerCase().includes(term)
        || account.ftpUser.toLowerCase().includes(term)
        || account.ftpType.toLowerCase().includes(term)
        || pipe.transform(account.ftpPort).includes(term);
    });
  }

  modalAdd() {
    this.account = {
      ftpAccountId: 0,
      ftpHost: null,
      ftpUser: null,
      ftpPassword: null,
      ftpDirectory: null,
      ftpType: null,
      ftpPort: null
    }
    this.modalTitle = "New Carrier";
    this.activateAddEditAccountsComponent = true;
  }

  modalEdit(item: any) {
    this.account = item;
    this.modalTitle = "Edit Carrier";
    this.activateAddEditAccountsComponent = true;
  }

  deleteAccount(item: any) {
    if (confirm("Are you sure you want to delete this account?")) {
      this.accountsService.deleteServer(item.ftpAccountId).subscribe(res => {
        var closeModalBtn = document.getElementById('add-edit-modal-close');
        if (closeModalBtn) {
          closeModalBtn.click();
        }

        var showDeleteSuccess = document.getElementById('delete-account-success-alert');
        if (showDeleteSuccess) {
          showDeleteSuccess.style.display = "block";
        }
        setTimeout(function () {
          if (showDeleteSuccess) {
            showDeleteSuccess.style.display = "none";
          }
        }, 4000);
      })
    }
  }

  modalClose() {
    this.activateAddEditAccountsComponent = false;
    this.accountsService.serversList$ = this.accountsService.getServersList();
    this.accounts$ = this.accountsService.serversList$;
  }

  sort(headerName: String) {
    this.isDescOrder = !this.isDescOrder;
    this.orderHeader = headerName;
  }

}


