import { FileTypesApiService } from './../../services/file-types-api.service';
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


  constructor(public feedsService: FeedsApiService, public fileTypesService: FileTypesApiService,
    public clientsService: ClientsApiService, public developersService: DevelopersApiService,
    public filesService: FilesService) { }

  ngOnInit(): void {
  }

  modalAdd() {
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    this.client = {
      clientId: 0,
      clientName: null,
      clientSurName: null,
      clientAge: null,
      clientAdress: null,
      profileCreationDate: mm + '/' + dd + '/' + yyyy
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
