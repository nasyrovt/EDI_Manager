import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FtpserverApiService {

  serversList$!: Observable<any[]>;
  serversList: any = [];
  serversMap: Map<number, string> = new Map();

  readonly APIUrl = "https://localhost:7255/api";

  constructor(private http: HttpClient) {
    this.serversList$ = this.getServersList();
    this.refreshServersMap();
  }

  refreshServersMap() {
    this.getServersList().subscribe(data => {
      this.serversList = data;

      for (let i = 0; i < data.length; i++) {
        this.serversMap.set(this.serversList[i].ftpAccountId, this.serversList[i].ftpHost);
      }
    });
  }

  //CRUD
  getServersList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + "/ftpaccounts");
  }

  addServer(data: any) {
    return this.http.post(this.APIUrl + "/ftpaccounts", data);
  }

  updateServer(id: number | string, data: any) {
    return this.http.put(this.APIUrl + "/ftpaccounts/" + id, data);
  }

  deleteServer(id: number | string) {
    return this.http.delete(this.APIUrl + "/ftpaccounts/" + id);
  }
}
