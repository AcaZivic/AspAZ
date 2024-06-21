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
    public class EfGetGroupsQuery : IGetGroupQuery
    {
        private readonly GameKingdomContext context;
        private readonly IMapper _mapper;

        public EfGetGroupsQuery(GameKingdomContext context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }

        public int Id => 100;

        public string Name => "Group search.";

        public PagedResponse<GroupDTO> Execute(GroupSearchDTO search)
        {
            var query = context.GroupEmps.AsQueryable();

            if(!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            if (search.MinNumberOfEmployees != null && search.MinNumberOfEmployees > 0)
            {
                query = query.Where(x => x.Employees.Count >= search.MinNumberOfEmployees);

            }

            return query.Paged<GroupDTO, Domain.GroupEmp>(search, _mapper);
        }
    }
}
