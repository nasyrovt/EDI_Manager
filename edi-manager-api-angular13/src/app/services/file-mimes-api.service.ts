import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FileMimesApiService {

  fileMimesList$!: Observable<any[]>;
  fileMimeList: any = [];
  fileMimesMap: Map<number, string> = new Map();

  readonly feedsAPIUrl = "https://localhost:7255/api";

  constructor(private http: HttpClient) {
    this.fileMimesList$ = this.getFileMimesList();
    this.refreshFileMimesMap();
  }

  refreshFileMimesMap() {
    this.getFileMimesList().subscribe(data => {
      this.fileMimeList = data;
      for (let i = 0; i < data.length; i++) {
        this.fileMimesMap.set(this.fileMimeList[i].fileMimeId, this.fileMimeList[i].fileMimeName);
      }
    });
  }


  //CRUD
  getFileMimesList(): Observable<any[]> {
    return this.http.get<any>(this.feedsAPIUrl + "/filemimes");
  }

  addFileMime(data: any) {
    return this.http.post(this.feedsAPIUrl + "/filemimes", data);
  }

  updateFileMime(id: number | string, data: any) {
    return this.http.put(this.feedsAPIUrl + "/filemimes/" + id, data);
  }

  deleteFileMime(id: number | string) {
    return this.http.delete(this.feedsAPIUrl + "/filemimes/" + id);
  }
}
