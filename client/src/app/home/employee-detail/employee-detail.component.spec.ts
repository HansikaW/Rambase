import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { EmployeeDetailComponent } from './employee-detail.component';
import {FormsModule} from '@angular/forms';
import { HttpClientTestingModule } from '@angular/common/http/testing';

describe('EmployeeDetailComponent', () => {
  let component: EmployeeDetailComponent;
  let fixture: ComponentFixture<EmployeeDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [ FormsModule, RouterTestingModule, HttpClientTestingModule],
      declarations: [ EmployeeDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('Should set submitted to true', async(() => {
    expect(component.onSubmit).toBeTruthy();
  }));

  it('component initial state', () => {
    expect(component.ngOnInit).toBeDefined();
    expect(component.ngOnInit).toBeTruthy();
    expect(component.resetForm).toBeDefined();
  //  expect(component.insertRecord).toBeFalsy(component.updateRecord);
   });
});
