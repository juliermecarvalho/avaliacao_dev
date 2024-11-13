import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class InvestmentService {

  public readonly API = 'http://localhost:5280/';

  constructor(private http: HttpClient) {}

  calculateFinalValue(frm: any): Observable<any> {
    const url = `${this.API}investments/calculate-final-value`;

    return this.http.post<any>(url, frm);
  }
}
