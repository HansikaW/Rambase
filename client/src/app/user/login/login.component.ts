import { Component, OnInit } from '@angular/core';
import { NgForm, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

import { UserService } from 'src/app/shared/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: []
})
export class LoginComponent implements OnInit {
  formModel = {
   UserName: '',
   Password:''
 } 
 
  constructor(private service:UserService, private router: Router, private http: HttpClient) { }

  ngOnInit() {
    if(localStorage.getItem('token') != null)
     this.router.navigateByUrl('/user/login');
  }
 
  onSubmit(form:NgForm){
    this.service.login(form.value).subscribe(
      (res: any) => {
        localStorage.setItem('token', res.token);
        this.router.navigateByUrl('/home');
      },
       err => {
         if(err.status == 400) {
         }
         else
          console.log(err);
       }
    );
  }
}
