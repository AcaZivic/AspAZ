using AspAZ.DataTransfer;
using AspAZ.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspAZ.Implementation.Profiles
{
    public class PriceListProfile : Profile
    {
        public PriceListProfile()
        {
            CreateMap<PriceList, CreatePriceListDTO>();
            CreateMap<CreatePriceListDTO, PriceList>();
            CreateMap<PriceList, PriceListDTO>();
            CreateMap<PriceListDTO, PriceList>();
        }
    }
}
