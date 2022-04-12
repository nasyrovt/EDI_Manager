import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PlatformsApiService {

  platformsList$!: Observable<any[]>;
  platformsList: any = [];
  platformsMap: Map<number, string> = new Map();

  readonly APIUrl = "https://localhost:7255/api";

  constructor(private http: HttpClient) {
    this.platformsList$ = this.getPlatformsList();
    this.refreshServersMap();
  }

  refreshServersMap() {
    this.getPlatformsList().subscribe(data => {
      this.platformsList = data;

      for (let i = 0; i < data.length; i++) {
        this.platformsMap.set(this.platformsList[i].platformId, this.platformsList[i].platformName);
      }
    });
  }

  //CRUD
  getPlatformsList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + "/platforms");
  }

  addPlatform(data: any) {
    return this.http.post(this.APIUrl + "/platforms", data);
  }

  updatePlatform(id: number | string, data: any) {
    return this.http.put(this.APIUrl + "/platforms/" + id, data);
  }

  deletePlatform(id: number | string) {
    return this.http.delete(this.APIUrl + "/platforms/" + id);
  }
}
