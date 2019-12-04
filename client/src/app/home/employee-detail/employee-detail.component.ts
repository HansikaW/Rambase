import { Component, OnInit } from '@angular/core';
import { EmployeeDetailService } from 'src/app/shared/employee-detail.service';
import { EmployeeDetail } from 'src/app/shared/employee-detail.model';
import {NgForm} from '@angular/forms';

@Component({
  selector: 'app-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.css']
})
export class EmployeeDetailComponent implements OnInit {

  constructor(private service: EmployeeDetailService) { }
    formData : EmployeeDetail
 
    ngOnInit() {
      this.resetForm();
  }
 
    resetForm(form?: NgForm){
      if(form != null)
      form.resetForm();
      this.service.formData ={
        EId:0,
        EmployeeName:'',
        PhoneNo:'',
        BDay:'',
        Nic:'',
      }
    }

    onSubmit(form:NgForm){
      if(this.service.formData.EId==0)
      this.insertRecord(form);
      else
      this.updateRecord(form);
    }

    insertRecord(form:NgForm){
      this.service.postEmployeeDetail().subscribe(
        res => {
          this.resetForm(form);
          this.service.refreshlist();
        },
        err => {
          console.log(err);
        }
      )
    }

    updateRecord(form:NgForm){
      this.service.putEmployeeDetail().subscribe(
        res => {
          this.resetForm(form);
          this.service.refreshlist();
        },
        err => {
          console.log(err);
        }
      )
    }
}
