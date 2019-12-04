import { BrowserModule } from '@angular/platform-browser';
//import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import{ HttpClientModule, HttpClient} from "@angular/common/http";
import { RouterModule } from '@angular/router';

import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { UserService } from './shared/user.service';
import { LoginComponent } from './user/login/login.component';
import { HomeComponent } from './home/home.component';
import { EmployeeDetailComponent } from './home/employee-detail/employee-detail.component';
import { EmployeeDetailListComponent } from './home/employee-detail-list/employee-detail-list.component';
import { EmployeeDetailService } from './shared/employee-detail.service';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    RegistrationComponent,
    LoginComponent,
    HomeComponent,
    EmployeeDetailComponent,
    EmployeeDetailListComponent,
  ],
  exports: [ 
      EmployeeDetailComponent, 
      EmployeeDetailListComponent,
      FormsModule 
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    RouterModule,
    CommonModule
  ],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ],
  providers: [UserService , EmployeeDetailService, HttpClientModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
export class CustomModule {}
