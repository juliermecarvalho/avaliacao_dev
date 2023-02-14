import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { InvestmentService } from '../services/investment.service';

@Component({
  selector: 'app-frm-investments',
  templateUrl: './frm-investments.component.html',
  styleUrls: ['./frm-investments.component.scss']
})
export class FrmInvestmentsComponent {
  frm: FormGroup;


  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );

  constructor(private breakpointObserver: BreakpointObserver, private formBuilder: FormBuilder, private investmentService: InvestmentService) {

    this.frm = this.formBuilder.group({
      initialValue: new FormControl(5, [Validators.required]),
      timeInMonths: new FormControl(5, [Validators.required])
    });

  }

  onSubmit(): void {


    this.investmentService.calculateFinalValue(this.frm.value).subscribe({
      next: (value: any) => {
        console.log("🚀 ~ file: frm-investments.component.ts:42 ~ FrmInvestmentsComponent ~ this.investmentService.calculateFinalValue ~ value", value)

      }

    })

  }

}
