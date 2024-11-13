import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { InvestmentResult } from './InvestmentResult';

@Injectable({
  providedIn: 'root',
})

export class InvestmentService {

  /**
   * The base URL for the API.
   */
  public readonly API = 'http://localhost:5280/';


  constructor(private http: HttpClient) {}

  /**
   * Calculates the final value of an investment.
   * @param frm - The form data containing investment details.
   * @returns An Observable containing the result of the calculation.
   */
  calculateFinalValue(frm: any): Observable<InvestmentResult> {
    const url = `${this.API}investments/calculate-final-value`;

    return this.http.post<InvestmentResult>(url, frm);
  }
}


