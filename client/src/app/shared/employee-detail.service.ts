import { Injectable } from '@angular/core';
import { EmployeeDetail } from './employee-detail.model';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class EmployeeDetailService {
  formData: EmployeeDetail;

  readonly rootURL = 'http://localhost:51417/api';
  list: EmployeeDetail[];

  constructor(private http: HttpClient) { }

  postEmployeeDetail() {
    return this.http.post<EmployeeDetail[]>(this.rootURL + '/EmployeeDetail', this.formData);
  }

  putEmployeeDetail() {
    return this.http.put('/api/EmployeeDetail/' + this.formData.EId, this.formData);
  }

  deleteEmployeeDetail(id) {
    return this.http.delete(this.rootURL + '/EmployeeDetail/' + id);
  }

  refreshlist() {
    this.http.get(this.rootURL + '/EmployeeDetail')
      .toPromise()
      .then(res => this.list = res as EmployeeDetail[]);
  }
}