using AspAZ.DataTransfer;
using AspAZ.Domain;
using AspYt.Application.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspAZ.Implementation.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<UpdateCategoryDto, Category>().
                ForMember(x => x.Name,
                y => y.MapFrom(z => z.Name));
            CreateMap<UpdateCategoryDto, Category>().
                ForMember(x => x.Description,
                y => y.MapFrom(z => z.Description));
             CreateMap<UpdateCategoryDto, Category>().
                ForMember(x => x.ParentId,
                y => y.MapFrom(z => z.ParentId));



            CreateMap<Category,CategoryDto>().ForMember(x=>x.Name,
                y=>y.MapFrom(z => z.Name));
            CreateMap< Category, CategoryDto>().ForMember(x => x.Description,
    y => y.MapFrom(z => z.Description));
            //CreateMap<Category, CategoryDto>().ForMember(x => x.Children,
            //    y => y.MapFrom(z => z.Children.Select(c=> new CategoryDto
            //    {
            //        Id = c.Id,
            //        Name = c.Name,
            //        Description = c.Description
            //    })));

        }
    }
}
