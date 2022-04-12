import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SftpService {

  readonly APIUrl = "https://localhost:7255/api";

  constructor(private http: HttpClient) { }

  testConnection(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + "/connection");
  }
}
