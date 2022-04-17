import { FtpserverApiService } from './../../services/ftpserver-api.service';
import { Input, Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-add-edit-ssh-keys',
  templateUrl: './add-edit-ssh-keys.component.html',
  styleUrls: ['./add-edit-ssh-keys.component.scss']
})
export class AddEditSshKeysComponent implements OnInit {

  keysList$!: Observable<any[]>;

  constructor(public service: FtpserverApiService) { }


  @Input() ssh: any;
  sshKeyId: number = 0;
  ftpHost: string = "";
  key: string = "";

  ngOnInit(): void {
    this.sshKeyId = this.ssh.sshKeyId;
    this.ftpHost = this.ssh.ftpHost;
    this.key = this.ssh.key;

    this.keysList$ = this.service.getSshKeysList();
  }

  addKey() {
    var ssh = {
      ftpHost: this.ftpHost,
      key: this.key
    }

    this.service.addSshKey(ssh).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if (closeModalBtn) {
        closeModalBtn.click();
      }

      var showAddSuccess = document.getElementById('add-key-success-alert');
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

  updateKey() {
    var ssh = {
      sshKeyId: this.sshKeyId,
      ftpHost: this.ftpHost,
      key: this.key
    }
    var id: number = this.sshKeyId;

    this.service.updateSshKey(id, ssh).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if (closeModalBtn) {
        closeModalBtn.click();
      }

      var showUpdateSuccess = document.getElementById('update-key-success-alert');
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



