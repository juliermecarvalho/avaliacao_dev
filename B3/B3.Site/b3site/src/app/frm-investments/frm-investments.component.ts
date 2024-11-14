import { Component, ViewChild } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { InvestmentService } from '../services/investment.service';
import { MatTable } from '@angular/material/table';
import { InvestmentResult } from '../services/InvestmentResult';

@Component({
  selector: 'app-frm-investments',
  templateUrl: './frm-investments.component.html',
  styleUrls: ['./frm-investments.component.scss'],
})
export class FrmInvestmentsComponent {
  investmentForm: FormGroup;
  errorMessage: string | null = null;
  displayedColumns: string[] = ['initialValue', 'timeInMonths', 'grossValue', 'netValue'];
  dataSource: any[] = [];
  @ViewChild(MatTable) table: MatTable<any> | undefined;
  isHandset$: Observable<boolean> = this.breakpointObserver
    .observe(Breakpoints.Handset)
    .pipe(
      map((result) => result.matches),
      shareReplay()
    );

  constructor(
    private breakpointObserver: BreakpointObserver,
    private formBuilder: FormBuilder,
    private investmentService: InvestmentService
  ) {
    this.investmentForm = this.formBuilder.group({
      initialValue: new FormControl(null, [Validators.required, Validators.min(1)]),
      timeInMonths: new FormControl(null, [Validators.required, Validators.min(2)]),
    });
  }

  onSubmit(): void {
    if (this.investmentForm.valid) {
      this.investmentService.calculateFinalValue(this.investmentForm.value).subscribe({
        next: (value: InvestmentResult) => {
          this.dataSource.push({
            initialValue: value.initialValue,
            timeInMonths: value.timeInMonths,
            grossValue: value.grossValue,
            netValue: value.netValue,
          });
          this.table?.renderRows();

          this.investmentForm.reset();
          this.investmentForm.markAsPending();
          this.errorMessage = null;

        }, error: (error) => {
          console.log(error);
          this.errorMessage = error.error;
        }
      });
    }
  }
}
