import { map, Observable, startWith } from 'rxjs';
import { FtpserverApiService } from './../../services/ftpserver-api.service';
import { FileMimesApiService } from '../../services/file-mimes-api.service';
import { Component, OnInit, PipeTransform } from '@angular/core';
import { FeedsApiService } from 'src/app/services/feeds-api.service';
import { ClientsApiService } from 'src/app/services/clients-api.service';
import { DevelopersApiService } from 'src/app/services/developers-api.service';
import { FilesService } from 'src/app/services/files-api.service';
import { FormControl } from '@angular/forms';
import { LowerCasePipe } from '@angular/common';

@Component({
  selector: 'app-show-feed',
  templateUrl: './show-feed.component.html',
  styleUrls: ['./show-feed.component.scss'],
  providers: [FileMimesApiService]
})
export class ShowFeedComponent implements OnInit {

  modalTitle: string = "";
  activateAddEditFeedComponent: boolean = false;
  feed: any;
  orderHeader: String = '';
  isDescOrder: boolean = true;
  filter = new FormControl('');
  feeds: any = [];
  feeds$: Observable<any[]>;

  constructor(public feedsService: FeedsApiService, public fileMimesService: FileMimesApiService,
    public clientsService: ClientsApiService, public developersService: DevelopersApiService,
    public filesService: FilesService, public serversService: FtpserverApiService) {
    this.feeds$ = this.feedsService.getFeedsList();
  }

  ngOnInit(): void {
    this.feeds$.subscribe(data => {
      this.feeds = data;
      this.feeds$ = this.filter.valueChanges.pipe(
        startWith(''),
        map(text => this.search(data, text))
      );
    })
  }

  search(feeds: any[], text: string): any[] {
    return feeds.filter(feed => {
      const term = text.toLowerCase();
      return feed.feedName.toLowerCase().includes(term)
        || this.feedsService.carriersMap.get(feed.carrierId)?.toLowerCase().includes(term)
        || this.clientsService.clientsMap.get(feed.clientId)?.toLowerCase().includes(term)
        || this.feedsService.frequenciesMap.get(feed.feedFrequencyId)?.toLowerCase().includes(term)
        || this.feedsService.securityTypesMap.get(feed.feedSecurityTypeId)?.toLowerCase().includes(term);
    });
  }

  modalAdd() {
    this.feed = {
      id: 0,
      feedName: null,
      sourceFileId: null,
      targetFileMimeId: null,
      inProduction: null,
      isChangesOnly: null,
      feedFrequencyId: null,
      businessDayOfMonth: null,
      frequencyTimes: null,
      series: null,
      weeklyRecurDay: null,
      startDate: null,
      endDate: null,
      feedSecurityTypeId: null,
      zipPassword: null,
      pgpPassword: null,
      clientId: null,
      carrierId: null,
      ftpAccountId: null,
      developerId: null
    }
    this.modalTitle = "EDI Manager > Feeds > Add New Feed";
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
    this.feeds$ = this.feedsService.feedsList$;
  }

  sort(headerName: String) {
    this.isDescOrder = !this.isDescOrder;
    this.orderHeader = headerName;
  }

}
