using AspAZ.DataTransfer;
using AspAZ.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspAZ.Implementation.Profiles
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<GroupEmp, GroupDTO>().ForMember(dto => dto.Name, x => x.MapFrom(y => y.Name));
            CreateMap<GroupDTO, GroupEmp>().ForMember(e => e.Name, x => x.MapFrom(g => g.Name)); 

        }
    }
}
