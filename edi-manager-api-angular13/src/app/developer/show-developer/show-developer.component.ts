import { FileMimesApiService } from '../../services/file-mimes-api.service';
import { Component, OnInit } from '@angular/core';
import { FeedsApiService } from 'src/app/services/feeds-api.service';
import { ClientsApiService } from 'src/app/services/clients-api.service';
import { DevelopersApiService } from 'src/app/services/developers-api.service';
import { FilesService } from 'src/app/services/files-api.service';

@Component({
  selector: 'app-show-developer',
  templateUrl: './show-developer.component.html',
  styleUrls: ['./show-developer.component.scss']
})
export class ShowDeveloperComponent implements OnInit {

  modalTitle: string = "";
  activateAddEditDeveloperComponent: boolean = false;
  developer: any;


  constructor(public feedsService: FeedsApiService, public fileTypesService: FileMimesApiService,
    public clientsService: ClientsApiService, public developersService: DevelopersApiService,
    public filesService: FilesService) { }

  ngOnInit(): void {
  }

  modalAdd() {

    this.developer = {
      developerId: 0,
      developerFirstName: null,
      developerLastName: null,
      developerMail: null,
      developerRole: null
    }
    this.modalTitle = "New Developer";
    this.activateAddEditDeveloperComponent = true;
  }

  modalEdit(item: any) {
    this.developer = item;
    this.modalTitle = "Edit Developer";
    this.activateAddEditDeveloperComponent = true;
  }

  deleteDeveloper(item: any) {
    if (confirm("Are you sure you want to delete this developer")) {
      this.developersService.deleteDeveloper(item.developerId).subscribe(res => {
        var closeModalBtn = document.getElementById('add-edit-modal-close');
        if (closeModalBtn) {
          closeModalBtn.click();
        }

        var showDeleteSuccess = document.getElementById('delete-developer-success-alert');
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
    this.activateAddEditDeveloperComponent = false;
    this.developersService.devsList$ = this.developersService.getDevelopersList();
  }

}
