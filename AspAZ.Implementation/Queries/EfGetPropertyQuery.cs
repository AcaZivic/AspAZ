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
    public class EfGetPropertyQuery : IGetPropertyQuery
    {
        private readonly GameKingdomContext context;
        private readonly IMapper _mapper;

        public EfGetPropertyQuery(GameKingdomContext context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }

        public int Id => 103;

        public string Name => "Property search.";

        public PagedResponse<PropertyDTO> Execute(PropertySearchDTO search)
        {
            var query = context.Properties.AsQueryable();

            if(!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.MeasureUnit) || !string.IsNullOrWhiteSpace(search.MeasureUnit))
            {
                query = query.Where(x => x.MeasureUnit.ToLower().Contains(search.MeasureUnit.ToLower()));
            }


            return query.Paged<PropertyDTO, Domain.Property>(search, _mapper);
        }
    }
}
