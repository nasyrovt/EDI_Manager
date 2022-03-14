import { ClientsApiService } from './../../services/clients-api.service';
import { FileTypesApiService } from './../../services/file-types-api.service';
import { Input, Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FeedsApiService } from 'src/app/services/feeds-api.service';
import { DevelopersApiService } from 'src/app/services/developers-api.service';
import { FilesService } from 'src/app/services/files-api.service';
import { EmailsChipComponent } from 'src/app/emails-chip/emails-chip.component';


@Component({
  selector: 'app-add-edit-feed',
  templateUrl: './add-edit-feed.component.html',
  styleUrls: ['./add-edit-feed.component.scss']
})
export class AddEditFeedComponent implements OnInit {

  feedsList$!: Observable<any[]>;
  fileTypesList$!: Observable<any[]>;
  filesList$!: Observable<any[]>;
  developersList$!: Observable<any[]>;
  clientsList$!: Observable<any[]>;

  emails: string[] = [];


  constructor(public feedsService: FeedsApiService, public fileTypesService: FileTypesApiService, public fileService: FilesService,
    public clientsService: ClientsApiService, public developersService: DevelopersApiService) { }


  @Input() feed: any;
  id: number = 0;
  feedName: string = "";
  clientId!: number;
  sourceFileId!: number;
  target!: number;
  targetEmails: string = "";
  developer!: number;
  ftpServerName: string = "";
  ftpUserName: string = "";

  ngOnInit(): void {
    this.id = this.feed.feedId;
    this.feedName = this.feed.feedName;
    this.clientId = this.feed.clientId;
    this.sourceFileId = this.feed.sourceFileId;
    this.target = this.feed.targetFileTypeId;
    this.targetEmails = this.feed.targetEmails;
    this.developer = this.feed.developerId;
    this.ftpServerName = this.feed.ftpServerName;
    this.ftpUserName = this.feed.ftpUserName;

    this.fileTypesList$ = this.fileTypesService.getFileTypesList();
    this.filesList$ = this.fileService.getFilesList();
    this.feedsList$ = this.feedsService.getFeedsList();
    this.clientsList$ = this.clientsService.getClientsList();
    this.developersList$ = this.developersService.getDevelopersList();
  }

  addFeed() {
    var feed = {
      feedName: this.feedName,
      clientId: this.clientId,
      sourceFileId: this.sourceFileId,
      targetFileTypeId: this.target,
      targetEmails: this.emails.filter((value, index) => this.emails.indexOf(value) == index).join("; "),
      developerId: this.developer,
      ftpServerName: this.ftpServerName,
      ftpUserName: this.ftpUserName
    }
    this.emails = [];

    this.feedsService.addFeed(feed).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if (closeModalBtn) {
        closeModalBtn.click();
      }

      var showAddSuccess = document.getElementById('add-success-alert');
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

  updateFeed() {
    var feed = {
      feedId: this.id,
      feedName: this.feedName,
      clientId: this.clientId,
      sourceFileId: this.sourceFileId,
      targetFileTypeId: this.target,
      targetEmails: this.emails.filter((value, index) => this.emails.indexOf(value) == index).join("; "),
      developerId: this.developer,
      ftpServerName: this.ftpServerName,
      ftpUserName: this.ftpUserName
    }
    var id: number = this.id;
    this.emails = [];

    this.feedsService.updateFeed(id, feed).subscribe(res => {
      var closeModalBtn = document.getElementById('add-edit-modal-close');
      if (closeModalBtn) {
        closeModalBtn.click();
      }

      var showUpdateSuccess = document.getElementById('update-success-alert');
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

  addEmail(mail: string) {
    this.emails.push(mail);
  }
}
