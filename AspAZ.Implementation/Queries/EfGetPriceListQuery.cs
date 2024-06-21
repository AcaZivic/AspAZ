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
    public class EfGetPriceListQuery : IGetPriceListQuery
    {
        private readonly GameKingdomContext context;
        private readonly IMapper _mapper;

        public EfGetPriceListQuery(GameKingdomContext context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }

        public int Id => 107;

        public string Name => "Price list search.";

        public PagedResponse<PriceListDTO> Execute(PriceListSearchDTO search)
        {
            var query = context.PriceLists.AsQueryable();

            query = query.Where(x => x.Price > search.MinPrice);

            //var x = query.ToList();

            if (search.Active == true)
                query = query.Where(x => x.DateTo != null && x.DateTo >= DateTime.Now && x.DateFrom <= DateTime.Now);
            else
                query = query.Where(x => x.DateTo == null || x.DateTo < DateTime.Now || x.DateFrom > DateTime.Now);



            return query.Paged<PriceListDTO, Domain.PriceList>(search, _mapper);

        }
    }
}
