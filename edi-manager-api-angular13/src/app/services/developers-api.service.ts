import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DevelopersApiService {

  devsList$!: Observable<any[]>;
  devsList: any = [];
  developerMap: Map<number, string> = new Map();

  readonly APIUrl = "https://localhost:7255/api";

  constructor(private http: HttpClient) {
    this.devsList$ = this.getDevelopersList();
    this.refreshDevsMap();
  }

  refreshDevsMap() {
    this.getDevelopersList().subscribe(data => {
      this.devsList = data;

      for (let i = 0; i < data.length; i++) {
        this.developerMap.set(this.devsList[i].developerId,
          this.devsList[i].developerFirstName + " " + this.devsList[i].developerLastName);
      }
    }
    );
  }

  //Developers
  getDevelopersList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + "/developers");
  }

  addDeveloper(data: any) {
    return this.http.post(this.APIUrl + "/developers", data);
  }

  updateDeveloper(id: number | string, data: any) {
    return this.http.put(this.APIUrl + "/developers/" + id, data);
  }

  deleteDeveloper(id: number | string) {
    return this.http.delete(this.APIUrl + "/developers/" + id);
  }
}
