import { ClientsApiService } from './../../services/clients-api.service';
import { FileTypesApiService } from './../../services/file-types-api.service';
import { Input, Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FeedsApiService } from 'src/app/services/feeds-api.service';
import { DevelopersApiService } from 'src/app/services/developers-api.service';
import { FilesService } from 'src/app/services/files-api.service';


@Component({
  selector: 'app-add-edit-developer',
  templateUrl: './add-edit-developer.component.html',
  styleUrls: ['./add-edit-developer.component.scss']
})
export class AddEditDeveloperComponent implements OnInit {

  feedsList$!: Observable<any[]>;
  fileTypesList$!: Observable<any[]>;
  filesList$!: Observable<any[]>;
  developersList$!: Observable<any[]>;
  clientsList$!: Observable<any[]>;


  constructor(public feedsService: FeedsApiService, public fileTypesService: FileTypesApiService, public fileService: FilesService,
    public clientsService: ClientsApiService, public developersService: DevelopersApiService) { }


  @Input() developer: any;
  developerId: number = 0;
  developerName: string = "";
  developerSurName: string = "";
  developerAge!: number;
  developerAdress: string = "";
  hireDate: string = "";

  ngOnInit(): void {
    this.developerId = this.developer.developerId;
    this.developerName = this.developer.developerName;
    this.developerSurName = this.developer.developerSurName;
    this.developerAge = this.developer.developerAge;
    this.developerAdress = this.developer.developerAdress;
    this.hireDate = this.developer.hireDate;

    this.fileTypesList$ = this.fileTypesService.getFileTypesList();
    this.filesList$ = this.fileService.getFilesList();
    this.feedsList$ = this.feedsService.getFeedsList();
    this.clientsList$ = this.clientsService.getClientsList();
    this.developersList$ = this.developersService.getDevelopersList();
  }

  addDeveloper() {
    var developer = {
      developerName: this.developerName,
      developerSurName: this.developerSurName,
      developerAge: this.developerAge,
      developerAdress: this.developerAdress,
      hireDate: this.hireDate
    }

    this.developersService.addDeveloper(developer).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if (closeModalBtn) {
        closeModalBtn.click();
      }

      var showAddSuccess = document.getElementById('add-developer-success-alert');
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

  updateDeveloper() {
    var developer = {
      developerId: this.developerId,
      developerName: this.developerName,
      developerSurName: this.developerSurName,
      developerAge: this.developerAge,
      developerAdress: this.developerAdress,
      hireDate: this.hireDate
    }
    var id: number = this.developerId;

    this.developersService.updateDeveloper(id, developer).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if (closeModalBtn) {
        closeModalBtn.click();
      }

      var showUpdateSuccess = document.getElementById('update-developer-success-alert');
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


