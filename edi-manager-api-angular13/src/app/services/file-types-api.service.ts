import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FileTypesApiService {

  fileTypesList$!: Observable<any[]>;
  fileTypesList: any = [];
  fileTypesMap: Map<number, string> = new Map();

  readonly feedsAPIUrl = "https://localhost:7255/api";

  constructor(private http: HttpClient) {
    this.fileTypesList$ = this.getFileTypesList();
    this.refreshFileTypesMap();
  }

  refreshFileTypesMap() {
    this.getFileTypesList().subscribe(data => {
      this.fileTypesList = data;
      for (let i = 0; i < data.length; i++) {
        this.fileTypesMap.set(this.fileTypesList[i].fileTypeId, this.fileTypesList[i].fileTypeName);
      }
    });
  }


  //CRUD
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
}
