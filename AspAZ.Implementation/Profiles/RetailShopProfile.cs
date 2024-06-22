using AspAZ.DataTransfer;
using AspAZ.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspAZ.Implementation.Profiles
{
    public class RetailShopProfile : Profile
    {
        public RetailShopProfile()
        {
            CreateMap<CreateRetailShopDTO, RetailShop>();
            CreateMap<RetailShop,CreateRetailShopDTO>();

            CreateMap<RetailShop, RetailShopDTO>();
            CreateMap<RetailShopDTO, RetailShop>();

            CreateMap<RetailShop, UpdateRetailShopDTO>();
            CreateMap<UpdateRetailShopDTO, RetailShop>();

        }
    }
}
