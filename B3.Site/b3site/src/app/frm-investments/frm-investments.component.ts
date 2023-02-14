import { Component, ViewChild } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { InvestmentService } from '../services/investment.service';
import { MatTable } from '@angular/material/table';




@Component({
  selector: 'app-frm-investments',
  templateUrl: './frm-investments.component.html',
  styleUrls: ['./frm-investments.component.scss']
})
export class FrmInvestmentsComponent {
  frm: FormGroup;
  displayedColumns: string[] = ['initialValue', 'timeInMonths', 'value'];
  elementos : any[] = [];
  dataSource: any[] = [];
  @ViewChild(MatTable) table: MatTable<any> | undefined;
  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver, private formBuilder: FormBuilder, private investmentService: InvestmentService) {

    this.frm = this.formBuilder.group({
      initialValue: new FormControl(null, [Validators.required]),
      timeInMonths: new FormControl(null, [Validators.required])
    });

  }

  onSubmit(): void {


    this.investmentService.calculateFinalValue(this.frm.value).subscribe({
      next: (value: any) => {

        this.dataSource.push({
          initialValue: this.frm.value.initialValue,
          timeInMonths: this.frm.value.timeInMonths,
          value: value
        });
        this.table?.renderRows();



        this.frm.reset();
        this.frm.markAsPending();

      }

    })

  }

}
