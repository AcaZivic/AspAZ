using AspAZ.DataTransfer;
using AspAZ.Domain;
using AspYt.Application.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspAZ.Implementation.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {

            CreateMap<CreateEmployeeDto, Employee>().ForMember(x=>x.UseCases,y=>y.MapFrom(obj=>obj.UseCases.Select(u=>new UserUseCase
            {
                UseCaseId = u
            })));
            CreateMap<Employee, CreateEmployeeDto >();
            CreateMap<UpdateEmployeeDto, Employee>();
            CreateMap<Employee, UpdateEmployeeDto>();

            CreateMap<EmployeeDTO, Employee>();
            CreateMap<Employee, EmployeeDTO>();
        }
    }
}
