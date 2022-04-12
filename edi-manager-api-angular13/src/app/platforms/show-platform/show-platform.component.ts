import { PlatformsApiService } from './../../services/platforms-api.service';
import { FileMimesApiService } from '../../services/file-mimes-api.service';
import { Component, OnInit } from '@angular/core';
import { FeedsApiService } from 'src/app/services/feeds-api.service';
import { ClientsApiService } from 'src/app/services/clients-api.service';
import { DevelopersApiService } from 'src/app/services/developers-api.service';
import { FilesService } from 'src/app/services/files-api.service';

@Component({
  selector: 'app-show-platform',
  templateUrl: './show-platform.component.html',
  styleUrls: ['./show-platform.component.scss']
})
export class ShowPlatformComponent implements OnInit {

  modalTitle: string = "";
  activateAddEditPlatformComponent: boolean = false;
  platform: any;


  constructor(public service: PlatformsApiService) { }

  ngOnInit(): void {
  }

  modalAdd() {

    this.platform = {
      platformId: 0,
      platformName: null
    }
    this.modalTitle = "New Platform";
    this.activateAddEditPlatformComponent = true;
  }

  modalEdit(item: any) {
    this.platform = item;
    this.modalTitle = "Edit Platform";
    this.activateAddEditPlatformComponent = true;
  }
  //
  deletePlatform(item: any) {
    if (confirm("Are you sure you want to delete this platform")) {
      this.service.deletePlatform(item.platformId).subscribe(res => {
        var closeModalBtn = document.getElementById('add-edit-modal-close');
        if (closeModalBtn) {
          closeModalBtn.click();
        }

        var showDeleteSuccess = document.getElementById('delete-platform-success-alert');
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
    this.activateAddEditPlatformComponent = false;
    this.service.platformsList$ = this.service.getPlatformsList();
  }

}

