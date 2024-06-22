using AspAZ.DataTransfer;
using AspAZ.Domain;
using AspYt.Application.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspAZ.Implementation.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreateCustomerDTO,Customer>();   
            CreateMap<Customer, CreateCustomerDTO>();

            CreateMap<CustomerDTO, Customer>();
            CreateMap<Customer, CustomerDTO>();
        }
    }
}
