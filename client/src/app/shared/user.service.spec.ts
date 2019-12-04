import { TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { UserService } from './user.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

describe('UserService', () => {
    let service: UserService;
    let httpMock: HttpTestingController;

  beforeEach(() => {TestBed.configureTestingModule({
    imports: [ ReactiveFormsModule, RouterTestingModule, HttpClientTestingModule],
    providers:[UserService],
   });
       service = TestBed.get(UserService);
       httpMock =TestBed.get(HttpTestingController);
 });
   
  afterEach(()=> {
    httpMock.verify();
  });
    
   it('should be created', () => {
    const service: UserService = TestBed.get(UserService);
    expect(service).toBeTruthy();
  });

  it('should retrieve from the API via GET',() =>{
      const dummyData=[
      {
        UserName: 'Hansika',
        FullName:'Hansika Wanniarachchi',
        Email: 'hansi@gmail.com'
      },
      {
        UserName: 'Jayani',
        FullName:'jayani Wanniarachchi',
        Email: 'hjw@gmail.com'
      }
    ];
    
    service.getUserProfile().subscribe(infor => {
      expect(dummyData.length).toBe(2);
      expect(infor).toEqual(dummyData);
    });
     
     const request = httpMock.expectOne(`${service.BaseURI}/UserProfile`);
   //  expect(request.request.url.endsWith("/UserProfile,,{headers:tokenHeader}")).toEqual(true);  
     expect(request.request.method).toBe('GET');
     request.flush(dummyData);
   })
   
   it('should post Registration data from the API via POST',() =>{
    const dummyReg=[
    {
      UserName: 'Hansika',
      FullName:'Hansika Wanniarachchi',
      Email: 'hansi@gmail.com',
      Password: '1234'
    },
    {
      UserName: 'Jayani',
      FullName:'jayani Wanniarachchi',
      Email: 'hjw@gmail.com',
      Password: '1234'
    }
  ];
  
  service.register().subscribe(Reg => {
    expect(dummyReg.length).toBe(2);
    expect(Reg).toEqual(dummyReg);
  });
   
   const requestReg = httpMock.expectOne(`${service.BaseURI}/ApplicationUser/Register`);
    expect(requestReg.request.method).toBe('POST');
    requestReg.flush(dummyReg);
   });
  
   it('should post LogIn data from the API via POST',() =>{
    const dummyLogin=[
    {
      UserName: 'Hansika',
      Password: '1234'
    },
    {
      UserName: 'Jayani',
      Password: '1234'
    }
  ];
  
  service.login(FormData).subscribe(login => {
    expect(dummyLogin.length).toBe(2);
    expect(login).toEqual(dummyLogin);
  });
   
    
   const requestLogin = httpMock.expectOne(`${service.BaseURI}/applicationUser/Login`);
   expect(requestLogin.request.method).toBe('POST');
   requestLogin.flush(dummyLogin);
});
});
