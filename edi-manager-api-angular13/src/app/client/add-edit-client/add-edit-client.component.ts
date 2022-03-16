import { ClientsApiService } from './../../services/clients-api.service';
import { FileTypesApiService } from './../../services/file-types-api.service';
import { Input, Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FeedsApiService } from 'src/app/services/feeds-api.service';
import { DevelopersApiService } from 'src/app/services/developers-api.service';
import { FilesService } from 'src/app/services/files-api.service';
import { EmailsChipComponent } from 'src/app/emails-chip/emails-chip.component';


@Component({
  selector: 'app-add-edit-client',
  templateUrl: './add-edit-client.component.html',
  styleUrls: ['./add-edit-client.component.scss']
})
export class AddEditClientComponent implements OnInit {

  feedsList$!: Observable<any[]>;
  fileTypesList$!: Observable<any[]>;
  filesList$!: Observable<any[]>;
  developersList$!: Observable<any[]>;
  clientsList$!: Observable<any[]>;

  emails: string[] = [];


  constructor(public feedsService: FeedsApiService, public fileTypesService: FileTypesApiService, public fileService: FilesService,
    public clientsService: ClientsApiService, public developersService: DevelopersApiService) { }


  @Input() client: any;
  clientId: number = 0;
  clientName: string = "";
  clientSurName: string = "";
  clientAge!: number;
  clientAdress: string = "";
  profileCreationDate: string = "";

  ngOnInit(): void {
    this.clientId = this.client.clientId;
    this.clientName = this.client.clientName;
    this.clientSurName = this.client.clientSurName;
    this.clientAge = this.client.clientAge;
    this.clientAdress = this.client.clientAdress;
    this.profileCreationDate = this.client.profileCreationDate;

    this.fileTypesList$ = this.fileTypesService.getFileTypesList();
    this.filesList$ = this.fileService.getFilesList();
    this.feedsList$ = this.feedsService.getFeedsList();
    this.clientsList$ = this.clientsService.getClientsList();
    this.developersList$ = this.developersService.getDevelopersList();
  }

  addClient() {
    var client = {
      clientName: this.clientName,
      clientSurName: this.clientSurName,
      clientAge: this.clientAge,
      clientAdress: this.clientAdress,
      profileCreationDate: this.profileCreationDate
    }

    this.clientsService.addClient(client).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if (closeModalBtn) {
        closeModalBtn.click();
      }

      var showAddSuccess = document.getElementById('add-client-success-alert');
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

  updateClient() {
    var client = {
      clientId: this.clientId,
      clientName: this.clientName,
      clientSurName: this.clientSurName,
      clientAge: this.clientAge,
      clientAdress: this.clientAdress,
      profileCreationDate: this.profileCreationDate
    }
    var id: number = this.clientId;

    this.clientsService.updateClient(id, client).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if (closeModalBtn) {
        closeModalBtn.click();
      }

      var showUpdateSuccess = document.getElementById('update-client-success-alert');
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
}

