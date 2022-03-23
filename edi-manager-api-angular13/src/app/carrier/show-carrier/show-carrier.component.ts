import { FileMimesApiService } from '../../services/file-mimes-api.service';
import { Component, OnInit } from '@angular/core';
import { FeedsApiService } from 'src/app/services/feeds-api.service';
import { ClientsApiService } from 'src/app/services/clients-api.service';
import { DevelopersApiService } from 'src/app/services/developers-api.service';
import { FilesService } from 'src/app/services/files-api.service';

@Component({
  selector: 'app-show-carrier',
  templateUrl: './show-carrier.component.html',
  styleUrls: ['./show-carrier.component.scss']
})
export class ShowCarrierComponent implements OnInit {

  modalTitle: string = "";
  activateAddEditCarrierComponent: boolean = false;
  carrier: any;


  constructor(public feedsService: FeedsApiService, public fileTypesService: FileMimesApiService,
    public clientsService: ClientsApiService, public developersService: DevelopersApiService,
    public filesService: FilesService) { }

  ngOnInit(): void {
  }

  modalAdd() {
    this.carrier = {
      carrierId: 0,
      carrierName: null,
      carrierTypeId: null,
      carrierTaxId: null,
      groupId: null,
      subGroupId: null,
      masterPolicyNumber: null,
      adress1: null,
      adress2: null,
      website: null,
      phones: null,
    }
    this.modalTitle = "New Carrier";
    this.activateAddEditCarrierComponent = true;
  }

  modalEdit(item: any) {
    this.carrier = item;
    this.modalTitle = "Edit Carrier";
    this.activateAddEditCarrierComponent = true;
  }

  deleteCarrier(item: any) {
    if (confirm("Are you sure you want to delete this carrier?")) {
      this.feedsService.deleteCarrier(item.carrierId).subscribe(res => {
        var closeModalBtn = document.getElementById('add-edit-modal-close');
        if (closeModalBtn) {
          closeModalBtn.click();
        }

        var showDeleteSuccess = document.getElementById('delete-carrier-success-alert');
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
    this.activateAddEditCarrierComponent = false;
    this.feedsService.carriersList$ = this.feedsService.getCarriersList();
  }

}

