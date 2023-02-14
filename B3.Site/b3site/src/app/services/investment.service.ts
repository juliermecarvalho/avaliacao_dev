import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class InvestmentService {


  private readonly API = 'http://localhost:32826/';

  constructor(private http: HttpClient) { }

  calculateFinalValue(frm: any): Observable<any> {
    const url = `${this.API}investments/calculate-final-value`


    let httpParams = new HttpParams();
    httpParams = httpParams
      .append('initialValue', frm.initialValue)
      .append('timeInMonths', frm.timeInMonths);



    return this.http.post<any>(url, null, { params: httpParams });
  }

}
