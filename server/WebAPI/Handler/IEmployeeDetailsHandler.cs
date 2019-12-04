using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Handler
{
    public interface IEmployeeDetailsHandler
    {
        Task<List<EmployeeDetail>> GetEmployeeDetails();
        Task<EmployeeDetail> GetEmployeeDetail(int id);
        Task<EmployeeDetail> PutEmployeeDetailAsync(int id, EmployeeDetail employeeDetail);
        Task<int> PostEmployeeDetail(EmployeeDetail employeeDetail);
        Task <int> DeleteEmployeeDetail(int id);
        bool EmployeeDetailExists(int id);
    }
}
