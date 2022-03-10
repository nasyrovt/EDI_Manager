import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { FeedsApiService } from 'src/app/feeds-api.service';

@Component({
  selector: 'app-show-feed',
  templateUrl: './show-feed.component.html',
  styleUrls: ['./show-feed.component.scss']
})
export class ShowFeedComponent implements OnInit {

  //Observables
  feedsList$!: Observable<any[]>; //! is for definitly assign
  filesList$!: Observable<any[]>;
  fileTypesList$!: Observable<any[]>;
  clientsList$!: Observable<string[]>;
  devsList$!: Observable<any[]>;

  //data arrays used later in Maps refresh functions
  filesList: any = [];
  fileTypesList: any = [];
  clientsList: any = [];
  devsList: any = [];


  //Maps to display data associate with foreign keys
  //Specifically to display Names instead of IDs
  filesMap: Map<number, string> = new Map();
  fileTypesMap: Map<number, string> = new Map();
  clientsMap: Map<number, string> = new Map();
  developerMap: Map<number, string> = new Map();




  constructor(private service: FeedsApiService) { }

  ngOnInit(): void {

    this.feedsList$ = this.service.getFeedsList();
    this.filesList$ = this.service.getFilesList();
    this.fileTypesList$ = this.service.getFileTypesList();
    this.clientsList$ = this.service.getClientsList();
    this.devsList$ = this.service.getDevelopersList();

    this.refreshFileTypesMap();
    this.refreshFilesMap();
    this.refreshDevsMap();
    this.refreshClientsMap();
  }

  refreshFileTypesMap() {
    this.service.getFileTypesList().subscribe(data => {
      this.fileTypesList = data;

      for (let i = 0; i < data.length; i++) {
        this.fileTypesMap.set(this.fileTypesList[i].fileTypeId, this.fileTypesList[i].fileTypeName);
      }
    }
    );
  }

  refreshFilesMap() {
    this.service.getFilesList().subscribe(data => {
      this.filesList = data;

      for (let i = 0; i < data.length; i++) {
        this.filesMap.set(this.filesList[i].fileId, this.filesList[i].fileName
          + "." + this.fileTypesMap.get(this.filesList[i].fileTypeId));
      }
    }
    );
  }

  refreshDevsMap() {
    this.service.getDevelopersList().subscribe(data => {
      this.devsList = data;

      for (let i = 0; i < data.length; i++) {
        this.developerMap.set(this.devsList[i].developerId,
          this.devsList[i].developerName + " " + this.devsList[i].developerSurName);
      }
    }
    );
  }

  refreshClientsMap() {
    this.service.getClientsList().subscribe(data => {
      this.clientsList = data;

      for (let i = 0; i < data.length; i++) {
        this.clientsMap.set(this.clientsList[i].clientId, this.clientsList[i].clientName + " " + this.clientsList[i].clientSurName);
      }
    }
    );
  }

}
