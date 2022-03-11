import { FileTypesApiService } from './file-types-api.service';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FeedsApiService {

  feedsList$!: Observable<any[]>;

  readonly feedsAPIUrl = "https://localhost:7255/api";

  constructor(private http: HttpClient, private fileTypesService: FileTypesApiService) {
    this.feedsList$ = this.getFeedsList();
  }

  //CRUD
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
    return this.http.put(this.feedsAPIUrl + "/feeds/$(id)", data);
  }

  deleteFeed(id: number | string) {
    return this.http.delete(this.feedsAPIUrl + "/feeds/$(id)");
  }


}
