import { Injectable, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})

export class ParkingService {
  private apiUrl = 'http://localhost:5281/api';
  //private apiUrl = 'https://aiico.onrender.com/api';

  constructor(private http: HttpClient) {}

  parkVehicle(payload: { location: string; vehicleType: string }): Observable<any> {
    return this.http.post<number>(`${this.apiUrl}/parking`, payload);
  }

  unparkVehicle(payload: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/parking/unpark`, payload);
  }

  getAllAvailableSpots() {
    return this.http.get<any>(`${this.apiUrl}/parking/available-parking`);
  }

  getAvailableTicketNumber(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/parking/available-tickets`);
  }
}
