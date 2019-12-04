using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class EmployeeDetailRepository : IEmployeeDetailRepository
    {
        private readonly AuthenticationContext _context;

        public EmployeeDetailRepository(AuthenticationContext context)
        {
            _context = context;
        }

        public void Insert<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<int> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync());
        }

        public async Task<List<EmployeeDetail>> GetAllAsync()
        {
            return await _context.EmployeeDetails.ToListAsync();
        }

        public async Task<EmployeeDetail> GetEmployeeDetailById(int id)
        {
            return await _context.EmployeeDetails.FindAsync(id);
        }

        public bool EmployeeDetailExists(int id)
        {
            return _context.EmployeeDetails.Any(e => e.EId == id);

        }
    }
}
