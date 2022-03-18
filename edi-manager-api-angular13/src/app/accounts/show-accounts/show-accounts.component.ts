import { FtpserverApiService } from './../../services/ftpserver-api.service';
import { FileTypesApiService } from './../../services/file-types-api.service';
import { Component, OnInit } from '@angular/core';
import { FeedsApiService } from 'src/app/services/feeds-api.service';
import { ClientsApiService } from 'src/app/services/clients-api.service';
import { DevelopersApiService } from 'src/app/services/developers-api.service';
import { FilesService } from 'src/app/services/files-api.service';

@Component({
  selector: 'app-show-accounts',
  templateUrl: './show-accounts.component.html',
  styleUrls: ['./show-accounts.component.scss']
})
export class ShowAccountsComponent implements OnInit {

  modalTitle: string = "";
  activateAddEditAccountsComponent: boolean = false;
  account: any;


  constructor(public feedsService: FeedsApiService, public fileTypesService: FileTypesApiService,
    public clientsService: ClientsApiService, public developersService: DevelopersApiService,
    public filesService: FilesService, public accountsService: FtpserverApiService) { }

  ngOnInit(): void {
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
  }

}


