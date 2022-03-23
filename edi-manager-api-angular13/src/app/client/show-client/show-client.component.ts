import { FileMimesApiService } from '../../services/file-mimes-api.service';
import { Component, OnInit } from '@angular/core';
import { FeedsApiService } from 'src/app/services/feeds-api.service';
import { ClientsApiService } from 'src/app/services/clients-api.service';
import { DevelopersApiService } from 'src/app/services/developers-api.service';
import { FilesService } from 'src/app/services/files-api.service';

@Component({
  selector: 'app-show-client',
  templateUrl: './show-client.component.html',
  styleUrls: ['./show-client.component.scss']
})
export class ShowClientComponent implements OnInit {

  modalTitle: string = "";
  activateAddEditClientComponent: boolean = false;
  client: any;


  constructor(public feedsService: FeedsApiService, public fileTypesService: FileMimesApiService,
    public clientsService: ClientsApiService, public developersService: DevelopersApiService,
    public filesService: FilesService) { }

  ngOnInit(): void {
  }

  modalAdd() {
    this.client = {
      clientId: 0,
      clientName: null,
      clientTaxId: null,
      contactName: null,
      contactMails: null,
      contactPhoneNumbers: null
    }
    this.modalTitle = "New Client";
    this.activateAddEditClientComponent = true;
  }

  modalEdit(item: any) {
    this.client = item;
    this.modalTitle = "Edit Feed";
    this.activateAddEditClientComponent = true;
  }

  deleteClient(item: any) {
    if (confirm("Are you sure you want to delete this client")) {
      this.clientsService.deleteClient(item.clientId).subscribe(res => {
        var closeModalBtn = document.getElementById('add-edit-modal-close');
        if (closeModalBtn) {
          closeModalBtn.click();
        }

        var showDeleteSuccess = document.getElementById('delete-client-success-alert');
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
    this.activateAddEditClientComponent = false;
    this.clientsService.clientsList$ = this.clientsService.getClientsList();
  }

}
