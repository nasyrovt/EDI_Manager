import { FileTypesApiService } from './../../services/file-types-api.service';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
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
    public filesService: FilesService) { }

  ngOnInit(): void {
  }

  modalAdd() {
    this.feed = {
      id: 0,
      feedName: null,
      clientId: null,
      sourceFileId: null,
      targetFileTypeId: null,
      targetEmails: null,
      developerId: null,
      ftpServerName: null,
      ftpUserName: null
    }
    this.modalTitle = "New Feed";
    this.activateAddEditFeedComponent = true;
  }

}
