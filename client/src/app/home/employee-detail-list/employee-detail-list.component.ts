import { Component, OnInit } from '@angular/core';
import { EmployeeDetailService } from 'src/app/shared/employee-detail.service';
import {EmployeeDetail} from './../../shared/employee-detail.model'

@Component({
  selector: 'app-employee-detail-list',
  templateUrl: './employee-detail-list.component.html',
  styleUrls: ['./employee-detail-list.component.css']
})
export class EmployeeDetailListComponent implements OnInit {

  constructor(private service: EmployeeDetailService) { }

  ngOnInit() {
    this.service.refreshlist();
  }

  populateForm(pd:EmployeeDetail){
    this.service.formData =Object.assign({},pd);
  }

  onDelete(EId){
    this.service.deleteEmployeeDetail(EId)
     .subscribe(res => {
       this.service.refreshlist();
     },
       err =>{
         console.log(err);
       })
    
  }
}
