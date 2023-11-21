﻿using AutoMapper;
using Demo.DAL.Models;
using Demo.PL.ViewModels;

namespace Demo.PL.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile() {
        //CreateMap<EmployeeViewModel , Employee>().ForMember(d=>d.Name , O=>O.MapFrom(s=>s.EmpName)).ReverseMap();
        CreateMap<EmployeeViewModel , Employee>().ReverseMap();
        }
    }
}
