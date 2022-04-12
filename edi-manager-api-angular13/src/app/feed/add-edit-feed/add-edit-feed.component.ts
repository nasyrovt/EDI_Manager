import { SftpService } from './../../services/sftp.service';
import { FtpserverApiService } from './../../services/ftpserver-api.service';
import { ClientsApiService } from './../../services/clients-api.service';
import { FileMimesApiService } from '../../services/file-mimes-api.service';
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
  freqTimes: number[] = new Array(12).fill(1).map((x, i) => i + 1)

  feedsList$!: Observable<any[]>;
  fileTypesList$!: Observable<any[]>;
  filesList$!: Observable<any[]>;
  developersList$!: Observable<any[]>;
  clientsList$!: Observable<any[]>;
  serversList$!: Observable<any[]>;
  carriersList$!: Observable<any[]>;
  // fileChangesList$!: Observable<any[]>;
  frequenciesList$!: Observable<any[]>;
  securityTypesList$!: Observable<any[]>;
  // statusesList$!: Observable<any[]>;

  emails: string[] = [];


  constructor(public feedsService: FeedsApiService, public fileTypesService: FileMimesApiService, public fileService: FilesService,
    public clientsService: ClientsApiService, public developersService: DevelopersApiService, public serversService: FtpserverApiService, public sftp: SftpService) { }


  @Input() feed: any;
  id: number = 0;
  feedName: string = "";
  sourceFileId!: number;
  targetFileMimeId!: number;
  inProduction!: number;
  isChangesOnly!: number;
  feedFrequencyId!: number;
  businessDayOfMonth!: number;
  frequencyTimes!: number;
  series: string = "";//++
  weeklyRecurDay!: number;
  startDate: string = "";//++
  endDate: string = "";//++
  feedSecurityTypeId!: number;
  zipPassword: string = "";
  pgpPassword: string = "";
  clientId!: number;
  carrierId!: number;
  ftpAccountId!: number;
  developer!: number;

  ngOnInit(): void {
    this.id = this.feed.feedId;
    this.feedName = this.feed.feedName;
    this.sourceFileId = this.feed.sourceFileId;
    this.targetFileMimeId = this.feed.targetFileMimeId;
    this.inProduction = this.feed.inProduction;
    this.isChangesOnly = this.feed.isChangesOnly;
    this.feedFrequencyId = this.feed.feedFrequencyId;
    this.businessDayOfMonth = this.feed.businessDayOfMonth;
    this.frequencyTimes = this.feed.frequencyTimes;
    this.series = this.feed.series;
    this.weeklyRecurDay = this.feed.weeklyRecurDay;
    this.startDate = this.feed.startDate;
    this.endDate = this.feed.endDate;
    this.feedSecurityTypeId = this.feed.feedSecurityTypeId;
    this.zipPassword = this.feed.zipPassword;
    this.pgpPassword = this.feed.pgpPassword;
    this.clientId = this.feed.clientId;
    this.carrierId = this.feed.carrierId;
    this.ftpAccountId = this.feed.ftpAccountId;
    this.developer = this.feed.developerId;

    this.fileTypesList$ = this.fileTypesService.getFileMimesList();
    this.filesList$ = this.fileService.getFilesList();
    this.feedsList$ = this.feedsService.getFeedsList();
    this.carriersList$ = this.feedsService.getCarriersList();
    this.clientsList$ = this.clientsService.getClientsList();
    this.developersList$ = this.developersService.getDevelopersList();
    this.serversList$ = this.serversService.getServersList();
    this.frequenciesList$ = this.feedsService.getFrequenciesList();
    this.securityTypesList$ = this.feedsService.getSecurityTypesList();
  }

  addFeed() {
    var feed = {
      feedName: this.feedName,
      sourceFileId: this.sourceFileId,
      targetFileMimeId: this.targetFileMimeId,
      inProduction: this.inProduction,
      isChangesOnly: this.isChangesOnly,
      feedFrequencyId: this.feedFrequencyId,
      businessDayOfMonth: this.businessDayOfMonth,
      frequencyTimes: this.frequencyTimes,
      series: this.series,
      weeklyRecurDay: this.weeklyRecurDay,
      startDate: this.startDate,
      endDate: this.endDate,
      feedSecurityTypeId: this.feedSecurityTypeId,
      zipPassword: this.zipPassword,
      pgpPassword: this.pgpPassword,
      clientId: this.clientId,
      carrierId: this.carrierId,
      ftpAccountId: this.ftpAccountId,
      developerId: this.developer
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
      sourceFileId: this.sourceFileId,
      targetFileMimeId: this.targetFileMimeId,
      inProduction: this.inProduction,
      isChangesOnly: this.isChangesOnly,
      feedFrequencyId: this.feedFrequencyId,
      businessDayOfMonth: this.businessDayOfMonth,
      frequencyTimes: this.frequencyTimes,
      series: this.series,
      weeklyRecurDay: this.weeklyRecurDay,
      startDate: this.startDate,
      endDate: this.endDate,
      feedSecurityTypeId: this.feedSecurityTypeId,
      zipPassword: this.zipPassword,
      pgpPassword: this.pgpPassword,
      clientId: this.clientId,
      carrierId: this.carrierId,
      ftpAccountId: this.ftpAccountId,
      developerId: this.developer
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

  testConn() {
    this.sftp.testConnection();
  }
}
