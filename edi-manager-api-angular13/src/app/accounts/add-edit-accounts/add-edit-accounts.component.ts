import { SftpService } from './../../services/sftp.service';
import { FtpserverApiService } from './../../services/ftpserver-api.service';
import { ClientsApiService } from './../../services/clients-api.service';
import { FileMimesApiService } from '../../services/file-mimes-api.service';
import { Input, Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FeedsApiService } from 'src/app/services/feeds-api.service';
import { DevelopersApiService } from 'src/app/services/developers-api.service';
import { FilesService } from 'src/app/services/files-api.service';


@Component({
  selector: 'app-add-edit-accounts',
  templateUrl: './add-edit-accounts.component.html',
  styleUrls: ['./add-edit-accounts.component.scss']
})
export class AddEditAccountsComponent implements OnInit {

  feedsList$!: Observable<any[]>;
  fileTypesList$!: Observable<any[]>;
  filesList$!: Observable<any[]>;
  developersList$!: Observable<any[]>;
  clientsList$!: Observable<any[]>;
  carrierTypesList$!: Observable<any[]>;
  accountsList$!: Observable<any[]>;

  messageConnectionTest = "";


  constructor(public feedsService: FeedsApiService, public fileTypesService: FileMimesApiService, public fileService: FilesService,
    public clientsService: ClientsApiService, public developersService: DevelopersApiService, public accountsService: FtpserverApiService, public sftp: SftpService) { }


  @Input() account: any;
  ftpAccountId: number = 0;
  ftpHost: string = "";
  ftpUser: string = "";
  ftpPassword: string = "";
  ftpDirectory: string = "";
  ftpType: string = "";
  ftpPort!: number;

  ngOnInit(): void {
    this.ftpAccountId = this.account.ftpAccountId;
    this.ftpHost = this.account.ftpHost;
    this.ftpUser = this.account.ftpUser;
    this.ftpPassword = this.account.ftpPassword;
    this.ftpDirectory = this.account.ftpDirectory;
    this.ftpType = this.account.ftpType;
    this.ftpPort = this.account.masterPolicyNftpPortumber;

    this.fileTypesList$ = this.fileTypesService.getFileMimesList();
    this.filesList$ = this.fileService.getFilesList();
    this.feedsList$ = this.feedsService.getFeedsList();
    this.clientsList$ = this.clientsService.getClientsList();
    this.developersList$ = this.developersService.getDevelopersList();
    this.carrierTypesList$ = this.feedsService.getCarrierTypesList();
    this.accountsList$ = this.accountsService.getServersList();
  }

  addAccount() {
    var account = {
      ftpHost: this.ftpHost,
      ftpUser: this.ftpUser,
      ftpPassword: this.ftpPassword,
      ftpDirectory: this.ftpDirectory,
      ftpType: this.ftpType,
      ftpPort: this.ftpPort
    }

    this.accountsService.addServer(account).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if (closeModalBtn) {
        closeModalBtn.click();
      }

      var showAddSuccess = document.getElementById('add-account-success-alert');
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

  updateAccount() {
    var account = {
      ftpAccountId: this.ftpAccountId,
      ftpHost: this.ftpHost,
      ftpUser: this.ftpUser,
      ftpPassword: this.ftpPassword,
      ftpDirectory: this.ftpDirectory,
      ftpType: this.ftpType,
      ftpPort: this.ftpPort
    }
    var id: number = this.ftpAccountId;

    this.accountsService.updateServer(id, account).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if (closeModalBtn) {
        closeModalBtn.click();
      }

      var showUpdateSuccess = document.getElementById('update-account-success-alert');
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

  testConn() {
    if (!this.ftpAccountId) return;
    var connectingSpinner = document.getElementById('connecting-spinner');
    if (connectingSpinner) { connectingSpinner.style.display = "block"; }

    this.sftp.testConnection(this.ftpAccountId).subscribe(res => {
      this.messageConnectionTest = res;

      if (res === "Successfully connected!") {
        var sftpTestSuccess = document.getElementById('test-success-alert');
        if (sftpTestSuccess) {
          if (connectingSpinner) {
            connectingSpinner.style.display = "none";
          }
          sftpTestSuccess.style.display = "block";
        }
        setTimeout(function () {
          if (sftpTestSuccess) {
            sftpTestSuccess.style.display = "none";
          }
        }, 4000);
      }

      else if (this.messageConnectionTest.indexOf('Host key fingerprint is ssh-rsa 2048 ') !== -1) {
        if (connectingSpinner) {
          connectingSpinner.style.display = "none";
        }
        var serverSshKey = this.messageConnectionTest.substring(this.messageConnectionTest.indexOf("is"), this.messageConnectionTest.length - 1);
        serverSshKey = serverSshKey.substring(serverSshKey.indexOf("8 ") + 2, serverSshKey.indexOf("."));
        if (confirm(res + "\nWould you like to save this key to database?")) {
          var ssh = {
            ftpHost: this.ftpHost,
            key: serverSshKey
          }
          this.accountsService.addSshKey(ssh).subscribe()
        }
      }

      else {
        var sftpTestError = document.getElementById('test-error-alert');
        if (sftpTestError) {
          if (connectingSpinner) {
            connectingSpinner.style.display = "none";
          }
          sftpTestError.style.display = "block";
        }
        setTimeout(function () {
          if (sftpTestError) {
            sftpTestError.style.display = "none";
          }
        }, 5000);
      }
    })

  }

  //For chips
  // addPhone(phone: string) {
  //   this.phonesList.push(phone);
  // }
}