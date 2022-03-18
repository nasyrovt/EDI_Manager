import { ClientsApiService } from './../../services/clients-api.service';
import { FileTypesApiService } from './../../services/file-types-api.service';
import { Input, Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FeedsApiService } from 'src/app/services/feeds-api.service';
import { DevelopersApiService } from 'src/app/services/developers-api.service';
import { FilesService } from 'src/app/services/files-api.service';


@Component({
  selector: 'app-add-edit-carrier',
  templateUrl: './add-edit-carrier.component.html',
  styleUrls: ['./add-edit-carrier.component.scss']
})
export class AddEditCarrierComponent implements OnInit {

  feedsList$!: Observable<any[]>;
  fileTypesList$!: Observable<any[]>;
  filesList$!: Observable<any[]>;
  developersList$!: Observable<any[]>;
  clientsList$!: Observable<any[]>;
  carrierTypesList$!: Observable<any[]>;


  constructor(public feedsService: FeedsApiService, public fileTypesService: FileTypesApiService, public fileService: FilesService,
    public clientsService: ClientsApiService, public developersService: DevelopersApiService) { }


  @Input() carrier: any;
  carrierId: number = 0;
  carrierName: string = "";
  carrierTypeId!: number;
  carrierTaxId!: number;
  groupId!: number;
  subGroupId!: number;
  masterPolicyNumber!: number;
  adress1: string = "";
  adress2: string = "";
  website: string = "";
  phones: string = "";

  ngOnInit(): void {
    this.carrierId = this.carrier.carrierId;
    this.carrierName = this.carrier.carrierName;
    this.carrierTypeId = this.carrier.carrierTypeId;
    this.carrierTaxId = this.carrier.carrierTaxId;
    this.groupId = this.carrier.groupId;
    this.subGroupId = this.carrier.subGroupId;
    this.masterPolicyNumber = this.carrier.masterPolicyNumber;
    this.adress1 = this.carrier.adress1;
    this.adress2 = this.carrier.adress2;
    this.website = this.carrier.website;
    this.phones = this.carrier.phones;

    this.fileTypesList$ = this.fileTypesService.getFileTypesList();
    this.filesList$ = this.fileService.getFilesList();
    this.feedsList$ = this.feedsService.getFeedsList();
    this.clientsList$ = this.clientsService.getClientsList();
    this.developersList$ = this.developersService.getDevelopersList();
    this.carrierTypesList$ = this.feedsService.getCarrierTypesList();
  }

  addCarrier() {
    var carrier = {
      carrierName: this.carrierName,
      carrierTypeId: this.carrierTypeId,
      carrierTaxId: this.carrierTaxId,
      groupId: this.groupId,
      subGroupId: this.subGroupId,
      masterPolicyNumber: this.masterPolicyNumber,
      adress1: this.adress1,
      adress2: this.adress2,
      website: this.website,
      phones: this.phones
    }

    this.feedsService.addCarrier(carrier).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if (closeModalBtn) {
        closeModalBtn.click();
      }

      var showAddSuccess = document.getElementById('add-carrier-success-alert');
      if (showAddSuccess) {
        showAddSuccess.style.display = "block";
      }
      setTimeout(function () {
        if (showAddSuccess) {
          showAddSuccess.style.display = "none";
        }
      }, 4000);
    })
  }

  updateCarrier() {
    var currentCarrier = {
      carrierId: this.carrierId,
      carrierName: this.carrierName,
      carrierTypeId: this.carrierTypeId,
      carrierTaxId: this.carrierTaxId,
      groupId: this.groupId,
      subGroupId: this.subGroupId,
      masterPolicyNumber: this.masterPolicyNumber,
      adress1: this.adress1,
      adress2: this.adress2,
      webSite: this.website,
      phones: this.phones
    }
    var id: number = this.carrierId;

    this.feedsService.updateCarrier(id, currentCarrier).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if (closeModalBtn) {
        closeModalBtn.click();
      }

      var showUpdateSuccess = document.getElementById('update-carrier-success-alert');
      if (showUpdateSuccess) {
        showUpdateSuccess.style.display = "block";
      }
      setTimeout(function () {
        if (showUpdateSuccess) {
          showUpdateSuccess.style.display = "none";
        }
      }, 4000);
    })
  }

  //For chips
  // addPhone(phone: string) {
  //   this.phonesList.push(phone);
  // }
}



