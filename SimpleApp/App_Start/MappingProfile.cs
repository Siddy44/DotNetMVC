using AutoMapper;
using SimpleApp.Dtos;
using SimpleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}