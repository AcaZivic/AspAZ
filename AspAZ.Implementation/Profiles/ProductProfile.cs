using AspAZ.DataAccess;
using AspAZ.DataTransfer;
using AspAZ.Domain;
using AspYt.Application.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspAZ.Implementation.Profiles
{
    public class ProductProfile : Profile
    {

        public ProductProfile()
        {
            CreateMap<CreateProductDTO, Product>();
            CreateMap<Product,CreateProductDTO> ();


            CreateMap<UpdateProductDTO, Product>();
            CreateMap<Product, UpdateProductDTO>();


            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();
           


        }
    }
}
