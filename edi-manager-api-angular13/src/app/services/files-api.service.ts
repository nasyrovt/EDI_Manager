import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FileTypesApiService } from './file-types-api.service';

@Injectable({
  providedIn: 'root'
})
export class FilesService {

  filesList$!: Observable<any[]>;
  filesList: any = [];
  filesMap: Map<number, string> = new Map();

  readonly APIUrl = "https://localhost:7255/api";

  constructor(private http: HttpClient, private fileTypesService: FileTypesApiService) {
    this.filesList$ = this.getFilesList();
    this.refreshFilesMap();
  }

  refreshFilesMap() {
    this.getFilesList().subscribe(data => {
      this.filesList = data;

      for (let i = 0; i < data.length; i++) {
        console.log(`This is ${this.filesList[i].fileId} times easier!`);
        this.filesMap.set(this.filesList[i].fileId, this.filesList[i].fileName
          + "." + this.fileTypesService.fileTypesMap.get(this.filesList[i].fileTypeId));
      }
    });
  }

  //CRUD
  getFilesList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + "/files");
  }

  addFile(data: any) {
    return this.http.post(this.APIUrl + "/files", data);
  }

  updateFile(id: number | string, data: any) {
    return this.http.put(this.APIUrl + "/files/$(id)", data);
  }

  deleteFile(id: number | string) {
    return this.http.delete(this.APIUrl + "/files/$(id)");
  }
}
