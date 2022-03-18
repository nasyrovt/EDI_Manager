import { FtpserverApiService } from './../../services/ftpserver-api.service';
import { ClientsApiService } from './../../services/clients-api.service';
import { FileTypesApiService } from './../../services/file-types-api.service';
import { Input, Component, OnInit } from '@angular/core';
import { Observable, range } from 'rxjs';
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

  showPGPPass = false;
  showZipPass = false;

  days: number[] = new Array(31).fill(1).map((x, i) => i + 1)
  recurDays = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"]
  freqTimes: number[] = new Array(13).fill(1).map((x, i) => i)

  feedsList$!: Observable<any[]>;
  fileTypesList$!: Observable<any[]>;
  filesList$!: Observable<any[]>;
  developersList$!: Observable<any[]>;
  clientsList$!: Observable<any[]>;
  serversList$!: Observable<any[]>;
  carriersList$!: Observable<any[]>;
  fileChangesList$!: Observable<any[]>;
  frequenciesList$!: Observable<any[]>;
  securityTypesList$!: Observable<any[]>;
  statusesList$!: Observable<any[]>;

  emails: string[] = [];


  constructor(public feedsService: FeedsApiService, public fileTypesService: FileTypesApiService, public fileService: FilesService,
    public clientsService: ClientsApiService, public developersService: DevelopersApiService, public serversService: FtpserverApiService) { }


  @Input() feed: any;
  id: number = 0;
  feedName: string = "";
  feedStatusId!: number;
  feedFileChangesId!: number;
  businessDayOfMonth!: number;
  feedFrequencyId!: number;
  frequencyTimes!: number;
  weeklyRecurDay!: number;
  feedSecurityTypeId!: number;
  zipPassword: string = "";
  pgpPassword: string = "";
  clientId!: number;
  sourceFileId!: number;
  target!: number;
  targetEmails: string = "";
  carrierId!: number;
  developer!: number;
  ftpAccountId!: number;

  ngOnInit(): void {
    this.id = this.feed.feedId;
    this.feedName = this.feed.feedName;
    this.feedStatusId = this.feed.feedStatusId;
    this.feedFileChangesId = this.feed.feedFileChangesId;
    this.businessDayOfMonth = this.feed.businessDayOfMonth;
    this.feedFrequencyId = this.feed.feedFrequencyId;
    this.frequencyTimes = this.feed.frequencyTimes;
    this.weeklyRecurDay = this.feed.weeklyRecurDay;
    this.feedSecurityTypeId = this.feed.feedSecurityTypeId;
    this.zipPassword = this.feed.zipPassword;
    this.pgpPassword = this.feed.pgpPassword;
    this.clientId = this.feed.clientId;
    this.sourceFileId = this.feed.sourceFileId;
    this.target = this.feed.targetFileTypeId;
    this.targetEmails = this.feed.targetEmails;
    this.carrierId = this.feed.carrierId;
    this.developer = this.feed.developerId;
    this.ftpAccountId = this.feed.ftpAccountId;

    this.fileTypesList$ = this.fileTypesService.getFileTypesList();
    this.filesList$ = this.fileService.getFilesList();
    this.feedsList$ = this.feedsService.getFeedsList();
    this.carriersList$ = this.feedsService.getCarriersList();
    this.clientsList$ = this.clientsService.getClientsList();
    this.developersList$ = this.developersService.getDevelopersList();
    this.serversList$ = this.serversService.getServersList();
    this.fileChangesList$ = this.feedsService.getFileChangesList();
    this.frequenciesList$ = this.feedsService.getFrequenciesList();
    this.securityTypesList$ = this.feedsService.getSecurityTypesList();
    this.statusesList$ = this.feedsService.getStatusesList();
  }

  addFeed() {
    var feed = {
      feedName: this.feedName,
      feedStatusId: this.feedStatusId,
      feedFileChangesId: this.feedFileChangesId,
      businessDayOfMonth: this.businessDayOfMonth,
      feedFrequencyId: this.feedFrequencyId,
      frequencyTimes: this.frequencyTimes,
      weeklyRecurDay: this.weeklyRecurDay,
      feedSecurityTypeId: this.feedSecurityTypeId,
      zipPassword: this.zipPassword,
      pgpPassword: this.pgpPassword,
      clientId: this.clientId,
      sourceFileId: this.sourceFileId,
      targetFileTypeId: this.target,
      carrierId: this.carrierId,
      developerId: this.developer,
      ftpAccountId: this.ftpAccountId
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
      feedStatusId: this.feedStatusId,
      feedFileChangesId: this.feedFileChangesId,
      businessDayOfMonth: this.businessDayOfMonth,
      feedFrequencyId: this.feedFrequencyId,
      frequencyTimes: this.frequencyTimes,
      weeklyRecurDay: this.weeklyRecurDay,
      feedSecurityTypeId: this.feedSecurityTypeId,
      zipPassword: this.zipPassword,
      pgpPassword: this.pgpPassword,
      clientId: this.clientId,
      sourceFileId: this.sourceFileId,
      targetFileTypeId: this.target,
      carrierId: this.carrierId,
      developerId: this.developer,
      ftpAccountId: this.ftpAccountId
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

  togglePgpPassword() {
    this.showPGPPass = !this.showPGPPass;
  }

  toggleZipPassword() {
    this.showZipPass = !this.showZipPass;
  }
}
