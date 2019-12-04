using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Enitities;
using WebAPI.Models;
using AutoMapper;

namespace WebAPI.Mapper
{
    public class Mapper : Profile
    {
        
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //Create all maps here
                cfg.CreateMap<EmployeeDetailEntity, EmployeeDetail>().ReverseMap();
            });

            return config.CreateMapper();
        }

    }
}
