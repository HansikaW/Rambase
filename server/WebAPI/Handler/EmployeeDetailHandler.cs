using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Enitities;
using WebAPI.Repositories;
using AutoMapper;

namespace WebAPI.Handler
{
    public class EmployeeDetailHandler : IEmployeeDetailsHandler
    { 
        private readonly IEmployeeDetailRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeDetailHandler(IEmployeeDetailRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<EmployeeDetail>> GetEmployeeDetails()
        {

            return _mapper.Map<List<EmployeeDetail>>(await _repository.GetAllAsync());
        }

        public async Task<EmployeeDetail> GetEmployeeDetail(int id)
        {
            var repo = await _repository.GetEmployeeDetailById(id);
            var employeeDetail = _mapper.Map<EmployeeDetail>(repo);

            if (employeeDetail == null)
            {
                return null;
            }
            return employeeDetail;
        }

        public async Task<EmployeeDetail> PutEmployeeDetailAsync(int id, EmployeeDetail employeeDetail)
        {
            try
            {
                if (employeeDetail == null)
                {
                    throw new ArgumentNullException(nameof(employeeDetail));
                }
               
                _mapper.Map<EmployeeDetailEntity>(employeeDetail);
                _repository.Update(employeeDetail);
                await _repository.SaveAllAsync();

                return employeeDetail;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }

        public async Task<int> PostEmployeeDetail(EmployeeDetail employeeDetail)
        {
            
            if (employeeDetail != null)
            {
             
                _repository.Insert(employeeDetail);
                await _repository.SaveAllAsync();

                _mapper.Map<EmployeeDetail>(employeeDetail);
                return employeeDetail.EId;
            }
            return 0;
        }

        public async Task<int> DeleteEmployeeDetail(int id)
        {
            int result = 0;
            
            if (id != 0)
            {
                var employeeDetail = await _repository.GetEmployeeDetailById(id);
                if (employeeDetail != null)
                {
                    _repository.Delete(employeeDetail);
                    await _repository.SaveAllAsync();
                }
                else
                {
                    return 0;
                }
                return employeeDetail.EId;
            }
            return result;
        }

            public bool EmployeeDetailExists(int id)
            {
                return _repository.EmployeeDetailExists(id);
            }
    }
  }

