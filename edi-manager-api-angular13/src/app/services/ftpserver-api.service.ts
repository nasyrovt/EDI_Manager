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

  keysList$!: Observable<any[]>;
  keysList: any = [];
  keysMap: Map<number, string> = new Map();

  readonly APIUrl = "https://localhost:7255/api";

  constructor(private http: HttpClient) {
    this.serversList$ = this.getServersList();
    this.keysList$ = this.getSshKeysList();
    this.refreshServersMap();
    this.refreshKeysMap();
  }

  refreshServersMap() {
    this.getServersList().subscribe(data => {
      this.serversList = data;

      for (let i = 0; i < data.length; i++) {
        this.serversMap.set(this.serversList[i].ftpAccountId, this.serversList[i].ftpHost);
      }
    });
  }

  refreshKeysMap() {
    this.getSshKeysList().subscribe(data => {
      this.keysList = data;

      for (let i = 0; i < data.length; i++) {
        this.keysMap.set(this.keysList[i].sshKeyId, this.keysList[i].ftpHost);
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

  //SSH Keys CRUD
  getSshKeysList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + "/sshkeys");
  }

  addSshKey(data: any) {
    return this.http.post(this.APIUrl + "/sshkeys", data);
  }

  updateSshKey(id: number | string, data: any) {
    return this.http.put(this.APIUrl + "/sshkeys/" + id, data);
  }

  deleteSshKey(id: number | string) {
    return this.http.delete(this.APIUrl + "/sshkeys/" + id);
  }
}
