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
using AspYt.Application.DTO;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace AspAZ.Implementation.Queries
{
    public class EfGetCartQuery : IGetCartQuery
    {
        private readonly GameKingdomContext context;
        private readonly IMapper _mapper;

        public EfGetCartQuery(GameKingdomContext context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }

        public int Id => 122;

        public string Name => "Cart search.";

        public PagedResponse<CartDTO> Execute(CartSearchDTO search)
        {
            var query = context.Carts.AsQueryable();


            //if(!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            //{
            //    query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            //}

            //if (search.HasChlidren != null)
            //{
            //    query = query.Where(x => x.Children.Count()>0);

            //}
            //if (!string.IsNullOrEmpty(search.Description) || !string.IsNullOrWhiteSpace(search.Description))
            //{
            //    query = query.Where(x => x.Description.ToLower().Contains(search.Description.ToLower()));
            //}
            if (search.CustomerId != null && search.CustomerId>0)
            {
                query = query.Where(x => x.CustomerId == search.CustomerId);
            }
            if (search.EmployeeId != null && search.EmployeeId > 0)
            {
                query = query.Where(x => x.EmployeeId == search.EmployeeId);
            }
            if (search.RetailShopId != null && search.RetailShopId > 0)
            {
                query = query.Where(x => x.RetailShopId == search.RetailShopId);
            }
            if (search.MinProductPerCart != null)
            {
                query = query.Where(x=>x.ProductCarts.Count() >= search.MinProductPerCart);
            }

            query = query.Include(x => x.ProductCarts);
            var arr = query.Paged<CartDTO, Domain.Cart>(search, _mapper);
           
            return arr;
        }
    }
}
