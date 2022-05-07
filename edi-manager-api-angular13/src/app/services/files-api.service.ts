import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { FileMimesApiService } from './file-mimes-api.service';

@Injectable({
  providedIn: 'root'
})
export class FilesService {

  filesList$!: Observable<any[]>;
  filesList: any = [];
  filesMap: Map<number, string> = new Map();

  readonly APIUrl = "https://localhost:7255/api";

  constructor(private http: HttpClient, private fileMimesService: FileMimesApiService) {
    this.filesList$ = this.getFilesList();
    this.refreshFilesMap();
  }

  refreshFilesMap() {
    this.getFilesList().subscribe(data => {
      this.filesList = data;

      for (let i = 0; i < data.length; i++) {
        this.filesMap.set(this.filesList[i].fileId, this.filesList[i].fileName
          + "." + this.fileMimesService.fileMimesMap.get(this.filesList[i].fileMimeId));
      }
    });
  }

  //CRUD
  getFilesList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + "/files");
  }

  addFile(data: any) {
    this.filesList.push(data);
    return this.http.post(this.APIUrl + "/files", data);
  }

  updateFile(id: number | string, data: any) {
    return this.http.put(this.APIUrl + "/files/" + id, data);
  }

  deleteFile(id: number | string) {
    return this.http.delete(this.APIUrl + "/files/" + id);
  }
}
