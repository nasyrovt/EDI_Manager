import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClientsApiService {

  clientsList$!: Observable<any[]>;
  clientsList: any = [];
  clientsMap: Map<number, string> = new Map();

  readonly APIUrl = "https://localhost:7255/api";

  constructor(private http: HttpClient) {
    this.clientsList$ = this.getClientsList();
    this.refreshClientsMap();
  }

  refreshClientsMap() {
    this.getClientsList().subscribe(data => {
      this.clientsList = data;

      for (let i = 0; i < data.length; i++) {
        this.clientsMap.set(this.clientsList[i].clientId, this.clientsList[i].clientName);
      }
    });
  }

  //CRUD
  getClientsList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + "/clients");
  }

  addClient(data: any) {
    return this.http.post(this.APIUrl + "/clients", data);
  }

  updateClient(id: number | string, data: any) {
    return this.http.put(this.APIUrl + "/clients/" + id, data);
  }

  deleteClient(id: number | string) {
    return this.http.delete(this.APIUrl + "/clients/" + id);
  }
}
