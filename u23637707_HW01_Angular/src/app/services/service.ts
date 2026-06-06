import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class Service {
  private baseUrl = 'https://localhost:7030/api/CampusBuzz';

  constructor(private http: HttpClient) {}

  fetchEvents(): Observable<any[]> {
    return this.http.get<any[]>(this.baseUrl);
  }

  fetchEventById(id: string): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/${id}`);
  }

  createEvent(payload: any): Observable<any> {
    return this.http.post<any>(this.baseUrl, payload);
  }

  modifyEvent(id: string, payload: any): Observable<any> {
    return this.http.put<any>(`${this.baseUrl}/${id}`, payload);
  }

  removeEvent(id: string): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}/${id}`);
  }
}