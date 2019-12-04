import { EmployeeDetail } from './employee-detail.model';

describe('EmployeeDetail', () => {
  it('should create an instance', () => {
    expect(new EmployeeDetail()).toBeTruthy();
  });

  it('should accept values', () => {
    let employeeDetail = new EmployeeDetail();
    employeeDetail = {
        EId: 1,
        EmployeeName: "Ruby",
        PhoneNo: "0123456",
        BDay: "10/04",
        Nic: "13214123V",
    }
    expect(employeeDetail.EId).toEqual(1);
    expect(employeeDetail.EmployeeName).toEqual("Ruby");
    expect(employeeDetail.PhoneNo).toEqual("0123456");
    expect(employeeDetail.BDay).toEqual("10/04");
    expect(employeeDetail.Nic).toEqual("13214123V");
});

});
