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
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<Movies, MoviesDto>();
            Mapper.CreateMap<MoviesDto, Movies>().ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}