import { getTestBed, TestBed } from '@angular/core/testing';

import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { InvestmentService } from './investment.service';

describe('InvestmentService', () => {
  let injector;
  let service: InvestmentService;
  let httpMock: HttpTestingController;


  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [InvestmentService]

    });
    //service = TestBed.inject(InvestmentService);

    injector = getTestBed();
    service = injector.get(InvestmentService);
    httpMock = injector.get(HttpTestingController);
  });


  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });


  describe('#InvestmentService', () => {
    it('checks if the parameters are correct', () => {
      const value = 391.2665

      service.calculateFinalValue({initialValue: 500 , timeInMonths: 6}).subscribe(v => {
        expect(value).toEqual(v);
      });

      const req = httpMock.expectOne(`${service.API}investments/calculate-final-value?initialValue=500&timeInMonths=6`);
      expect(req.request.method).toBe("POST");
      req.flush(value);
    });
  });

});
