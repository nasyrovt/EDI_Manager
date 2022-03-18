import { FileTypesApiService } from './file-types-api.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FeedsApiService {

  feedsList$!: Observable<any[]>;
  carriersList$!: Observable<any[]>;
  fileChangesList$!: Observable<any[]>;
  frequenciesList$!: Observable<any[]>;
  securityTypesList$!: Observable<any[]>;
  statusesList$!: Observable<any[]>;

  carriersList: any = [];
  carriersMap: Map<number, string> = new Map();
  fileChangesList: any = [];
  fileChangesMap: Map<number, string> = new Map();
  frequenciesList: any = [];
  frequenciesMap: Map<number, string> = new Map();
  securityTypesList: any = [];
  securityTypesMap: Map<number, string> = new Map();
  statusesList: any = [];
  statusesMap: Map<number, string> = new Map();

  readonly feedsAPIUrl = "https://localhost:7255/api";

  constructor(private http: HttpClient, private fileTypesService: FileTypesApiService) {
    this.feedsList$ = this.getFeedsList();
    this.carriersList$ = this.getCarriersList();
    this.fileChangesList$ = this.getFileChangesList();
    this.frequenciesList$ = this.getFrequenciesList();
    this.securityTypesList$ = this.getSecurityTypesList();
    this.statusesList$ = this.getStatusesList();
    this.refreshAllMaps();
  }

  private refreshAllMaps() {
    this.refreshCarriersMap();
    this.refreshFileChangesMap();
    this.refreshFrequenciesMap();
    this.refreshSecurTypesMap();
    this.refreshStatusesMap();
  }

  refreshStatusesMap() {
    this.getStatusesList().subscribe(data => {
      this.statusesList = data;

      for (let i = 0; i < data.length; i++) {
        this.statusesMap.set(this.statusesList[i].feedStatusId, this.statusesList[i].feedStatusName);
      }
    });
  }

  refreshSecurTypesMap() {
    this.getSecurityTypesList().subscribe(data => {
      this.securityTypesList = data;

      for (let i = 0; i < data.length; i++) {
        this.securityTypesMap.set(this.securityTypesList[i].feedSecurityTypeId, this.securityTypesList[i].feedSecurityTypeName);
      }
    });
  }

  refreshFrequenciesMap() {
    this.getFrequenciesList().subscribe(data => {
      this.frequenciesList = data;

      for (let i = 0; i < data.length; i++) {
        this.frequenciesMap.set(this.frequenciesList[i].feedFrequencyId, this.frequenciesList[i].feedFrequencyName);
      }
    });
  }

  refreshFileChangesMap() {
    this.getFileChangesList().subscribe(data => {
      this.fileChangesList = data;

      for (let i = 0; i < data.length; i++) {
        this.fileChangesMap.set(this.fileChangesList[i].feedFileChangesId, this.fileChangesList[i].feedFileChangesName);
      }
    });
  }

  refreshCarriersMap() {
    this.getCarriersList().subscribe(data => {
      this.carriersList = data;

      for (let i = 0; i < data.length; i++) {
        this.carriersMap.set(this.carriersList[i].carrierId, this.carriersList[i].carrierName);
      }
    });
  }

  //CRUD Feeds
  getFeedsList(): Observable<any[]> {
    //if (!this.isFeedFetched) {
    const response = this.http.get<any>(this.feedsAPIUrl + "/feeds");
    //this.feeds = response;
    return response;
  }

  addFeed(data: any) {
    const addObservable = this.http.post(this.feedsAPIUrl + "/feeds", data);
    // Add addObservable result to this.feeds
    return addObservable
  }

  updateFeed(id: number | string, data: any) {
    return this.http.put(this.feedsAPIUrl + "/feeds/" + id, data);
  }

  deleteFeed(id: number | string) {
    return this.http.delete(this.feedsAPIUrl + "/feeds/" + id);
  }

  //Additional carriers/fileChange/frequencies/securityTypes/statuses CRUD-getters
  getCarriersList(): Observable<any[]> {
    return this.http.get<any>(this.feedsAPIUrl + "/carriers");
  }

  getFileChangesList(): Observable<any[]> {
    return this.http.get<any>(this.feedsAPIUrl + "/feedfilechanges");
  }

  getFrequenciesList(): Observable<any[]> {
    return this.http.get<any>(this.feedsAPIUrl + "/feedfrequencies");
  }

  getSecurityTypesList(): Observable<any[]> {
    return this.http.get<any>(this.feedsAPIUrl + "/feedsecuritytypes");
  }

  getStatusesList(): Observable<any[]> {
    return this.http.get<any>(this.feedsAPIUrl + "/feedstatus");
  }

}
