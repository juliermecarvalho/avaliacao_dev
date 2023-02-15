import { LayoutModule } from '@angular/cdk/layout';
import { waitForAsync, ComponentFixture, TestBed, getTestBed } from '@angular/core/testing';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';

import { FrmInvestmentsComponent } from './frm-investments.component';
import { InvestmentService } from '../services/investment.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatNativeDateModule } from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { CurrencyMaskModule } from 'ng2-currency-mask';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

describe('FrmInvestmentsComponent', () => {
  let component: FrmInvestmentsComponent;
  let fixture: ComponentFixture<FrmInvestmentsComponent>;
  let injector;
  let service: InvestmentService;
  let httpMock: HttpTestingController;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [FrmInvestmentsComponent],
      imports: [
        NoopAnimationsModule,
        LayoutModule,
        MatButtonModule,
        MatIconModule,
        MatListModule,
        MatSidenavModule,
        MatToolbarModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        MatNativeDateModule,
        MatInputModule,
        MatTableModule,
        CurrencyMaskModule,
        HttpClientTestingModule
      ],
      providers: [InvestmentService]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FrmInvestmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();

    injector = getTestBed();
    service = injector.get(InvestmentService);
    httpMock = injector.get(HttpTestingController);
  });

  it('should compile', () => {
    expect(component).toBeTruthy();
  });


  describe('#FrmInvestmentsComponent', () => {
    it('checks if frm invalid', () => {
      component.onSubmit()
      expect(component.frm.valid).toBeFalse();

      httpMock.expectNone(`${service.API}investments/calculate-final-value?initialValue=500&timeInMonths=6`)
    });


    it('checks if frm valid', () => {
      component.frm.patchValue({
        initialValue: 44,
        timeInMonths: 3
      })
      component.onSubmit()
      expect(component.frm.valid).toBeTrue();
    });


    it('checks that the parameters are correct when the onsubmit method is called', () => {
      const value = 391.2665

      component.frm.patchValue({
        initialValue: 44,
        timeInMonths: 3
      })
      component.onSubmit()

      const req = httpMock.expectOne(`${service.API}investments/calculate-final-value?initialValue=${component.frm.value.initialValue}&timeInMonths=${component.frm.value.timeInMonths}`);
      expect(req.request.method).toBe("POST");
      req.flush(value);
    });
  });

});
