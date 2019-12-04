import { TestBed } from '@angular/core/testing';
import {HttpClientTestingModule,HttpTestingController} from '@angular/common/http/testing';
import { EmployeeDetailService } from './employee-detail.service';
import { EmployeeDetail } from './employee-detail.model';

describe('EmployeeDetailService', () => {
   let service: EmployeeDetailService;
   let httpMock: HttpTestingController;

  beforeEach(() => { 
    TestBed.configureTestingModule({
     imports: [HttpClientTestingModule], 
     providers: [EmployeeDetailService]
    });

    service = TestBed.get(EmployeeDetailService);
    httpMock= TestBed.get(HttpTestingController);
  });

   afterEach(() =>{ 
     httpMock.verify();
   });

   it('should be created', () => {
    const service: EmployeeDetailService = TestBed.get(EmployeeDetailService);
    expect(service).toBeTruthy();
  });

   it('should send employee detail from API via POST', () => {
      const dummyEmployee: EmployeeDetail[] =[{
        EId: 1,
        EmployeeName: "Ruby",
        PhoneNo: "0123456",
        BDay: "10/04",
        Nic: "13214123V",
      },
      {
        EId: 1,
        EmployeeName: "Ruby",
        PhoneNo: "0123456",
        BDay: "10/04",
        Nic: "13214123V",
      },
    ];

     service.postEmployeeDetail().subscribe(employeeDetails =>{
        expect(employeeDetails.length).toBe(2);
        expect(employeeDetails).toEqual(dummyEmployee);
     });

     const request = httpMock.expectOne(`${service.rootURL}/EmployeeDetail`);
     expect(request.request.method).toBe('POST');
     request.flush(dummyEmployee);
   });
/*
   xit('should insert employee detail from API via PUT', () => {
    const dummyEmployeePUT: EmployeeDetail[] =[{
      EId: 1,
      EmployeeName: "Ruby",
      PhoneNo: "0123456",
      BDay: "10/04",
      Nic: "13214123V",
    },
    {
      EId: 1,
      EmployeeName: "Ruby",
      PhoneNo: "0123456",
      BDay: "10/04",
      Nic: "13214123V",
    },
  ];

  service.putEmployeeDetail().subscribe(employeeDetails =>{
      expect(dummyEmployeePUT.length).toBe(2);
      expect(employeeDetails).toEqual(dummyEmployeePUT);
   });

   const requestPut = httpMock.expectOne(`${service.rootURL}/EmployeeDetail/${service.formData.EId}`);
   expect(requestPut.request.method).toBe('PUT');
   requestPut.flush(dummyEmployeePUT);
   });
  
  xit('should Delete employee detail from API via DELETE', () => {
    const dummyEmployeeDelete: EmployeeDetail[] =[{
      EId: 1,
      EmployeeName: "Ruby",
      PhoneNo: "0123456",
      BDay: "10/04",
      Nic: "13214123V",
    },
    {
      EId: 1,
      EmployeeName: "Ruby",
      PhoneNo: "0123456",
      BDay: "10/04",
      Nic: "13214123V",
    },
  ];

   service.deleteEmployeeDetail(id).subscribe(employeeDetails =>{
      expect(employeeDetails.length-1).toBe(0);
      expect(employeeDetails).toEqual(dummyEmployeeDelete);
   });

   const requestDelete = httpMock.expectOne(`${service.rootURL}/EmployeeDetail/${id}`);
   expect(requestDelete.request.method).toBe('DELETE');
   requestDelete.flush(dummyEmployeeDelete);
   });
  */
  
});
