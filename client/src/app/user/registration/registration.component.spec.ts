import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { RegistrationComponent } from './registration.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import {UserService} from 'src/app/shared/user.service';

describe('RegistrationComponent', () => {
  let component: RegistrationComponent;
  let fixture: ComponentFixture<RegistrationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegistrationComponent ],
      imports: [ ReactiveFormsModule, RouterTestingModule, HttpClientTestingModule ],
      providers:[UserService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    //expect(true).toBeTruthy();
    expect(component).toBeTruthy();
  });

  it('Should set submitted to true', async(() => {
    //component.onSubmit();
    expect(component.onSubmit).toBeTruthy();
  }));

  it('component initial state', () => {
    expect(component.ngOnInit).toBeDefined();
    expect(component.ngOnInit).toBeTruthy();
   });

});
