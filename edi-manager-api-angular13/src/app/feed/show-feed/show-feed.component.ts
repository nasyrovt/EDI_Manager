import { FtpserverApiService } from './../../services/ftpserver-api.service';
import { FileTypesApiService } from './../../services/file-types-api.service';
import { Component, OnInit } from '@angular/core';
import { FeedsApiService } from 'src/app/services/feeds-api.service';
import { ClientsApiService } from 'src/app/services/clients-api.service';
import { DevelopersApiService } from 'src/app/services/developers-api.service';
import { FilesService } from 'src/app/services/files-api.service';

@Component({
  selector: 'app-show-feed',
  templateUrl: './show-feed.component.html',
  styleUrls: ['./show-feed.component.scss'],
  providers: [FileTypesApiService]
})
export class ShowFeedComponent implements OnInit {

  modalTitle: string = "";
  activateAddEditFeedComponent: boolean = false;
  feed: any;


  constructor(public feedsService: FeedsApiService, public fileTypesService: FileTypesApiService,
    public clientsService: ClientsApiService, public developersService: DevelopersApiService,
    public filesService: FilesService, public serversService: FtpserverApiService) { }

  ngOnInit(): void {
  }

  modalAdd() {
    this.feed = {
      id: 0,
      feedName: null,
      feedStatus: null,
      businessDayOfMonth: null,
      frequency: null,
      frequencyTimes: null,
      weeklyRecurDay: null,
      feedSecurityType: null,
      zipPassword: null,
      pgpPassword: null,
      clientId: null,
      sourceFileId: null,
      targetFileTypeId: null,
      carrierId: null,
      developerId: null,
      ftpAccountId: null
    }
    this.modalTitle = "New Feed";
    this.activateAddEditFeedComponent = true;
  }

  modalEdit(item: any) {
    this.feed = item;
    this.modalTitle = "Edit Feed";
    this.activateAddEditFeedComponent = true;
  }

  deleteFeed(item: any) {
    if (confirm("Are you sure you want to delete this feed")) {
      this.feedsService.deleteFeed(item.feedId).subscribe(res => {
        var closeModalBtn = document.getElementById('add-edit-modal-close');
        if (closeModalBtn) {
          closeModalBtn.click();
        }

        var showDeleteSuccess = document.getElementById('delete-success-alert');
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
    this.activateAddEditFeedComponent = false;
    this.feedsService.feedsList$ = this.feedsService.getFeedsList();
  }

}
