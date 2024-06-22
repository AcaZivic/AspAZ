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
    public class EfGetCustomerQuery : IGetCustomerQuery
    {
        private readonly GameKingdomContext context;
        private readonly IMapper _mapper;

        public EfGetCustomerQuery(GameKingdomContext context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }

        public int Id => 117;

        public string Name => "Customer search.";

        public PagedResponse<CustomerDTO> Execute(CustomerSearchDTO search)
        {
            var query = context.Customers.AsQueryable();

            //var x =query.Select(x => x.Children).ToList();

            if(!string.IsNullOrWhiteSpace(search.FirstName))
            {
                query = query.Where(x => x.FirstName.ToLower().Contains(search.FirstName.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(search.LastName))
            {
                query = query.Where(x => x.LastName.ToLower().Contains(search.LastName.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(search.StreetAddress))
            {
                query = query.Where(x => x.StreetAddress.ToLower().Contains(search.StreetAddress.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(search.TaxID.ToString()))
            {
                query = query.Where(x => x.TaxID.ToString().ToLower().Contains(search.TaxID.ToString().ToLower()));
            }



           


            return query.Paged<CustomerDTO, Domain.Customer>(search, _mapper);
        }
    }
}
