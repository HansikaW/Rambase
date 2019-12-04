using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories
{
   public interface IEmployeeDetailRepository
    {
        void Insert<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        Task<int> SaveAllAsync();
        Task<List<EmployeeDetail>> GetAllAsync();
        Task<EmployeeDetail> GetEmployeeDetailById(int id);
        bool EmployeeDetailExists(int id);

    }
}
