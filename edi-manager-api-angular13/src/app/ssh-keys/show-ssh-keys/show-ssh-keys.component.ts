import { FtpserverApiService } from './../../services/ftpserver-api.service';
import { PlatformsApiService } from './../../services/platforms-api.service';
import { FileMimesApiService } from '../../services/file-mimes-api.service';
import { Component, OnInit } from '@angular/core';
import { FeedsApiService } from 'src/app/services/feeds-api.service';
import { ClientsApiService } from 'src/app/services/clients-api.service';
import { DevelopersApiService } from 'src/app/services/developers-api.service';
import { FilesService } from 'src/app/services/files-api.service';

@Component({
  selector: 'app-show-ssh-keys',
  templateUrl: './show-ssh-keys.component.html',
  styleUrls: ['./show-ssh-keys.component.scss']
})
export class ShowSshKeysComponent implements OnInit {

  modalTitle: string = "";
  activateAddEditSSHKeyComponent: boolean = false;
  ssh: any;


  constructor(public service: FtpserverApiService) { }

  ngOnInit(): void {
  }

  modalAdd() {

    this.ssh = {
      sshKeyId: 0,
      ftpHost: null,
      key: null
    }
    this.modalTitle = "New Key";
    this.activateAddEditSSHKeyComponent = true;
  }

  modalEdit(item: any) {
    this.ssh = item;
    this.modalTitle = "Edit Key";
    this.activateAddEditSSHKeyComponent = true;
  }
  //
  deleteKey(item: any) {
    if (confirm("Are you sure you want to delete this key?")) {
      this.service.deleteSshKey(item.sshKeyId).subscribe(res => {
        var closeModalBtn = document.getElementById('add-edit-modal-close');
        if (closeModalBtn) {
          closeModalBtn.click();
        }

        var showDeleteSuccess = document.getElementById('delete-key-success-alert');
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
    this.activateAddEditSSHKeyComponent = false;
    this.service.keysList$ = this.service.getSshKeysList();
  }

}
