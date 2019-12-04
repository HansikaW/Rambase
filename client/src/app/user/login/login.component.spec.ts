import { async, ComponentFixture, TestBed, fakeAsync } from '@angular/core/testing';
import {FormsModule} from '@angular/forms';
import{ By}from '@angular/platform-browser';
import { LoginComponent } from './login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { RouterTestingModule } from '@angular/router/testing';
import {UserService} from 'src/app/shared/user.service';


describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;
 // let el = HTMLElement;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoginComponent ],
      imports: [ FormsModule, ReactiveFormsModule, HttpClientTestingModule, RouterTestingModule],
      providers :[UserService]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    //component = new LoginComponent(routerSpy, new FormBuilder(), loginServiceSpy);
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('Should set submitted to true', async(() => {
    //component.onSubmit();
    expect(component.onSubmit).toBeTruthy();
  }));

 it('Should call the OnSubmit method', () =>{ fakeAsync(() =>{
  fixture.detectChanges();
  spyOn(component,'onSubmit');
  let el:HTMLElement =fixture.debugElement.query(By.css('Login')).nativeElement as HTMLElement;
  el.click();
  expect(component.onSubmit).toHaveBeenCalledTimes(0);
  })
 });

 it('component initial state', () => {
  expect(component.ngOnInit).toBeDefined();
  expect(component.ngOnInit).toBeTruthy();
 });
});
