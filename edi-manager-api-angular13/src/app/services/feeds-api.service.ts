import { FileMimesApiService } from './file-mimes-api.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FeedsApiService {

  feedsList$!: Observable<any[]>;
  carriersList$!: Observable<any[]>;
  carrierTypesList$!: Observable<any[]>;
  frequenciesList$!: Observable<any[]>;
  securityTypesList$!: Observable<any[]>;
  

  carriersList: any = [];
  carriersMap: Map<number, string> = new Map();
  carrierTypesList: any = [];
  carrierTypesMap: Map<number, string> = new Map();
  frequenciesList: any = [];
  frequenciesMap: Map<number, string> = new Map();
  securityTypesList: any = [];
  securityTypesMap: Map<number, string> = new Map();

  readonly feedsAPIUrl = "https://localhost:7255/api";

  constructor(private http: HttpClient, private fileTypesService: FileMimesApiService) {
    this.feedsList$ = this.getFeedsList();
    this.carriersList$ = this.getCarriersList();
    this.frequenciesList$ = this.getFrequenciesList();
    this.securityTypesList$ = this.getSecurityTypesList();
    this.carrierTypesList$ = this.getCarrierTypesList();
    this.refreshAllMaps();
  }

  private refreshAllMaps() {
    this.refreshCarriersMap();
    this.refreshFrequenciesMap();
    this.refreshSecurTypesMap();
    this.refreshCarrierTypesMap();
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

  refreshCarriersMap() {
    this.getCarriersList().subscribe(data => {
      this.carriersList = data;

      for (let i = 0; i < data.length; i++) {
        this.carriersMap.set(this.carriersList[i].carrierId, this.carriersList[i].carrierName);
      }
    });
  }

  refreshCarrierTypesMap() {
    this.getCarrierTypesList().subscribe(data => {
      this.carrierTypesList = data;

      for (let i = 0; i < data.length; i++) {
        this.carrierTypesMap.set(this.carrierTypesList[i].carrierTypeId, this.carrierTypesList[i].carrierTypeName);
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

  //Carrier CRUD
  getCarriersList(): Observable<any[]> {
    return this.http.get<any>(this.feedsAPIUrl + "/carriers");
  }

  addCarrier(data: any) {
    const addObservable = this.http.post(this.feedsAPIUrl + "/carriers", data);
    // Add addObservable result to this.feeds
    return addObservable
  }

  updateCarrier(id: number | string, data: any) {
    const response = this.http.put(this.feedsAPIUrl + "/carriers/" + id, data);
    return response;
  }

  deleteCarrier(id: number | string) {
    return this.http.delete(this.feedsAPIUrl + "/carriers/" + id);
  }

  //Additional fileChange/frequencies/securityTypes/statuses CRUD-getters
  getFileChangesList(): Observable<any[]> {
    return this.http.get<any>(this.feedsAPIUrl + "/feedfilechanges");
  }

  getCarrierTypesList(): Observable<any[]> {
    return this.http.get<any>(this.feedsAPIUrl + "/carriertypes");
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
