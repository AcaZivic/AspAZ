using AspAZ.Application;
using AspAZ.Application.DataTransfer;
using AspAZ.Application.DTO;
using AspAZ.Application.UseCases.Queries;
using AspAZ.DataAccess;
using AspAZ.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Implementation.Queries
{
    public class EfGetManufacturerQuery : IGetManufacturerQuery
    {

        private readonly GameKingdomContext _context;

        public EfGetManufacturerQuery(GameKingdomContext context)
        {
            _context = context;
        }

        public int Id => 101;

        public string Name => "Manufacturer Search";

        public PagedResponse<ManufacturerDTO> Execute(ManufacturerSearchDTO search)
        {
            var query = _context.Manufacturers.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }
            if (search.MinNumberOfProducts != null && search.MinNumberOfProducts>0)
            {
                query = query.Where(x=>x.Products.Count >= search.MinNumberOfProducts);

            }


            var skipCount = search.PerPage * (search.Page - 1);

           
            var reponse = new PagedResponse<ManufacturerDTO>
            {
                CurrentPage = search.Page,
                PerPage = search.PerPage,
                TotalCount = query.Count(),
                Data = query.Skip(skipCount).Take(search.PerPage).Select(x => new ManufacturerDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                }).ToList()
            };

            return reponse;
        }
    }
}
