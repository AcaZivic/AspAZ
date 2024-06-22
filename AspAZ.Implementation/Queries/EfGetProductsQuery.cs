using AspAZ.Application.DataTransfer;
using AspAZ.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AspAZ.Implementation.Extensions;
using AutoMapper;
using AspAZ.Application.DTO;
using AspAZ.DataTransfer;
using AspAZ.Application.UseCases.Queries;

namespace AspAZ.Implementation.Queries
{
    public class EfGetProductsQuery : IGetProductQuery
    {
        private readonly GameKingdomContext context;
        private readonly IMapper _mapper;

        public EfGetProductsQuery(GameKingdomContext context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }

        public int Id => 111;

        public string Name => "Product search.";

        public PagedResponse<ProductDTO> Execute(ProductSearchDTO search)
        {
            var query = context.Products.AsQueryable();
            var x = query.Where(x => x.Id == 3).Select(y => y.PriceList.Price).First();

            if (search.Id != null)
            {
                query = query.Where(x=>x.Id == search.Id);
            }

            if(!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            if (search.Price != null && search.Price > 0)
            {
                query = query.Where(x => x.PriceList.Price>search.Price);

            }

            if (search.CategoryId != null && search.CategoryId > 0)
            {
                query = query.Where(x => x.CategoryId == search.CategoryId);
            }

            if (search.ManufacturerId != null && search.ManufacturerId > 0)
            {
                query = query.Where(x => x.ManufacturerId == search.ManufacturerId);
            }

            if (search.BarCode != null)
            {
                query = query.Where(x => x.BarCode == search.BarCode);
            }
            if (search.ProductCode != null)
            {
                query = query.Where(x => x.ProductCode == search.ProductCode);
            }


            var result = query.Paged<ProductDTO, Domain.Product>(search, _mapper);

            var temp = result.Data;

            foreach (var item in temp)
            {
                item.Price = context.PriceLists.Find(item.PriceListId).Price;
                item.ManufacturerName = context.Manufacturers.Find(item.ManufacturerId).Name;
                item.CategoryName= context.Categories.Find(item.CategoryId).Name;
                item.Properties = context.Products.Select(x => x.ProductProperties.Select(y => new ProductPropertyDTO
                {
                    PropertyId = y.PropertyId,
                    Value = y.Value
                })).First();
            }

            result.Data = temp;


            return result;
        }
    }
}
