using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private AuthenticationContext _context;
		private readonly ILogger<EmployeeDetailRepository> _logger;

		public EmployeeDetailRepository(AuthenticationContext context, ILogger<EmployeeDetailRepository> logger)
		{
			_context = context;
			_logger = logger;
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
			_logger.LogInformation("Message displayed: {Message}");
			return await _context.EmployeeDetails.ToListAsync();
        }

        public async Task<EmployeeDetail> GetEmployeeDetailById(int id)
        {
			_logger.LogInformation("Message displayed: {Message}");
			return await _context.EmployeeDetails.FindAsync(id);
        }

        public bool EmployeeDetailExists(int id)
        {
			_logger.LogInformation("Message displayed: {Message}");
			return _context.EmployeeDetails.Any(e => e.EId == id);

        }
    }
}
