import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FeedsApiService {

  readonly feedsAPIUrl = "https://localhost:7255/api";

  constructor(private http: HttpClient) { }

  //Feeds
  getFeedsList(): Observable<any[]> {
    return this.http.get<any>(this.feedsAPIUrl + "/feeds");
  }

  addFeed(data: any) {
    return this.http.post(this.feedsAPIUrl + "/feeds", data);
  }

  updateFeed(id: number | string, data: any) {
    return this.http.put(this.feedsAPIUrl + "/feeds/$(id)", data);
  }

  deleteFeed(id: number | string) {
    return this.http.delete(this.feedsAPIUrl + "/feeds/$(id)");
  }

  //Files
  getFilesList(): Observable<any[]> {
    return this.http.get<any>(this.feedsAPIUrl + "/files");
  }

  addFile(data: any) {
    return this.http.post(this.feedsAPIUrl + "/files", data);
  }

  updateFile(id: number | string, data: any) {
    return this.http.put(this.feedsAPIUrl + "/files/$(id)", data);
  }

  deleteFile(id: number | string) {
    return this.http.delete(this.feedsAPIUrl + "/files/$(id)");
  }

  //FileTypes
  getFileTypesList(): Observable<any[]> {
    return this.http.get<any>(this.feedsAPIUrl + "/fileTypes");
  }

  addFileType(data: any) {
    return this.http.post(this.feedsAPIUrl + "/fileTypes", data);
  }

  updateFileType(id: number | string, data: any) {
    return this.http.put(this.feedsAPIUrl + "/fileTypes/$(id)", data);
  }

  deleteFileType(id: number | string) {
    return this.http.delete(this.feedsAPIUrl + "/fileTypes/$(id)");
  }

  //Developers
  getDevelopersList(): Observable<any[]> {
    return this.http.get<any>(this.feedsAPIUrl + "/developers");
  }

  addDeveloper(data: any) {
    return this.http.post(this.feedsAPIUrl + "/developers", data);
  }

  updateDeveloper(id: number | string, data: any) {
    return this.http.put(this.feedsAPIUrl + "/developers/$(id)", data);
  }

  deleteDeveloper(id: number | string) {
    return this.http.delete(this.feedsAPIUrl + "/developers/$(id)");
  }

  //Clients
  getClientsList(): Observable<any[]> {
    return this.http.get<any>(this.feedsAPIUrl + "/clients");
  }

  addClient(data: any) {
    return this.http.post(this.feedsAPIUrl + "/clients", data);
  }

  updateClient(id: number | string, data: any) {
    return this.http.put(this.feedsAPIUrl + "/clients/$(id)", data);
  }

  deleteClient(id: number | string) {
    return this.http.delete(this.feedsAPIUrl + "/clients/$(id)");
  }


}
