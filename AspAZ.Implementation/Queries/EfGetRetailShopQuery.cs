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

namespace AspAZ.Implementation.Queries
{
    public class EfGetRetailShopQuery : IGetRetailShopQuery
    {
        private readonly GameKingdomContext context;
        private readonly IMapper _mapper;

        public EfGetRetailShopQuery(GameKingdomContext context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }

        public int Id => 115;

        public string Name => "Retail shop search.";

        public PagedResponse<RetailShopDTO> Execute(RetailShopSearchDTO search)
        {
            var query = context.RetailShops.AsQueryable();

            //var x =query.Select(x => x.Children).ToList();

            if (!string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(search.Address))
            {
                query = query.Where(x => x.Address.ToLower().Contains(search.Address.ToLower()) || x.AddressNum.ToLower().Contains(search.Address.ToLower()));
            }


            if ( !string.IsNullOrWhiteSpace(search.City))
            {
                query = query.Where(x => x.City.ToLower().Contains(search.City.ToLower()));
            }

            if ( !string.IsNullOrWhiteSpace(search.Telephone))
            {
                query = query.Where(x => x.Telephone.ToLower().Contains(search.Telephone.ToLower()));
            }
            //if (search.HasChlidren != null)
            //{
            //    query = query.Where(x => x.Children.Count()>0);

            //}
            //if (!string.IsNullOrEmpty(search.Description) || !string.IsNullOrWhiteSpace(search.Description))
            //{
            //    query = query.Where(x => x.Description.ToLower().Contains(search.Description.ToLower()));
            //}
            //if (search.ParentId != null)
            //{
            //    query = query.Where(x=>x.ParentId==search.ParentId);
            //}

            return query.Paged<RetailShopDTO, Domain.RetailShop>(search, _mapper);

        }
    }
}
