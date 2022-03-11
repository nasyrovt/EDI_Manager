import { ClientsApiService } from './../../services/clients-api.service';
import { FileTypesApiService } from './../../services/file-types-api.service';
import { Input, Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FeedsApiService } from 'src/app/services/feeds-api.service';
import { ShowFeedComponent } from '../show-feed/show-feed.component';
import { DevelopersApiService } from 'src/app/services/developers-api.service';
import { FilesService } from 'src/app/services/files-api.service';

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


  constructor(public feedsService: FeedsApiService, public fileTypesService: FileTypesApiService, public fileService: FilesService,
    public clientsService: ClientsApiService, public developersService: DevelopersApiService) { }


  @Input() feed: any;
  id: number = 0;
  feedName: string = "";
  clientId!: number;
  sourceFileId!: number;
  targetFileTypeId!: number;
  targetEmails: string = "";
  developerId!: number;
  ftpServerName: string = "";
  ftpUserName: string = "";

  ngOnInit(): void {
    this.id = this.feed.id;
    this.feedName = this.feed.feedName;
    this.clientId = this.feed.clientId;
    this.sourceFileId = this.feed.sourceFileId;
    this.targetFileTypeId = this.feed.targetFileTypeId;
    this.targetEmails = this.feed.targetEmails;
    this.developerId = this.feed.developerId;
    this.ftpServerName = this.feed.ftpServerName;
    this.ftpUserName = this.feed.ftpUserName;

    this.fileTypesList$ = this.fileTypesService.getFileTypesList();
    this.filesList$ = this.fileService.getFilesList();
    this.feedsList$ = this.feedsService.getFeedsList();
    this.clientsList$ = this.clientsService.getClientsList();
    this.developersList$ = this.developersService.getDevelopersList();
  }
}
