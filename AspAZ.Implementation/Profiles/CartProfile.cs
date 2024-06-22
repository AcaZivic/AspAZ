using AspAZ.DataTransfer;
using AspAZ.Domain;
using AspYt.Application.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspAZ.Implementation.Profiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<CreateCartDto, Cart>()
             .ForMember(x => x.CustomerId, opt => opt.MapFrom(y => y.CustomerId))
             .ForMember(x => x.EmployeeId, opt => opt.MapFrom(y => y.EmployeeId))
             .ForMember(x => x.RetailShopId, opt => opt.MapFrom(y => y.RetailShopId))
             .ForMember(x => x.ProductCarts, opt => opt.MapFrom(y => y.ProductCarts.Select(z => new ProductCart
             {
                 ProductId = z.ProductId,
                 Quantity = z.Quantity
             })));

            CreateMap<Cart,CreateCartDto>();
        }
    }
}
