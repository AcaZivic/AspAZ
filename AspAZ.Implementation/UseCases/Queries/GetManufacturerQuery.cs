using AspAZ.Application.DTO;
using AspAZ.Implementation.UseCases;
using AspAZ.Application.UseCases.Queries;
using AspAZ.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspAZ.DataTransfer;
using AspAZ.Application.DataTransfer;

namespace AspAZ.Implementation.UseCases.Queries
{
    public class GetManufacturerQuery : EfUseCase, IGetManufacturerQuery
    {
        public GetManufacturerQuery(GameKingdomContext context) : base(context)
        {
        }

        public int Id => 1;

        public string Name => "Search Manufacturer";

        public PagedResponse<ManufacturerDTO> Execute(ManufacturerSearchDTO search)
        {
            var query = Context.Manufacturers.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            if (search.MinNumberOfProducts.HasValue && search.MinNumberOfProducts >= 0)
            {
                query = query.Where(x => x.Products.Count() >= search.MinNumberOfProducts);
            }

            int totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            //16 PerPage = 5, Page = 2

            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<ManufacturerDTO>
            {
                CurrentPage = page,
                Data = query.Select(x => new ManufacturerDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToList(),
                PerPage = perPage,
                TotalCount = totalCount,
            };
        }
    }
}
