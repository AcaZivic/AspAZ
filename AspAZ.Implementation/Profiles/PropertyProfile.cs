using AspAZ.DataTransfer;
using AspAZ.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspAZ.Implementation.Profiles
{
    public class PropertyProfile : Profile
    {
        public PropertyProfile()
        {
            CreateMap<Property, PropertyDTO>();
            CreateMap<PropertyDTO, Property>();
            CreateMap<Property, PropertyUpdateDTO>();
            CreateMap<PropertyUpdateDTO, Property>();
        }
    }
}
