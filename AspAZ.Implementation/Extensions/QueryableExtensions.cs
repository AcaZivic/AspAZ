using AspAZ.Application.DataTransfer;
using AspAZ.Application.DTO;
using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace AspAZ.Implementation.Extensions
{
    public static class QueryableExtensions
    {
        public static PagedResponse<TDto> Paged<TDto, TEntity>(
            this IQueryable<TEntity> query, PagedSearch search, IMapper mapper)
            where TDto : class
        {
            var skipCount = search.PerPage * (search.Page - 1);
            
            var skipped = query.Skip(skipCount).Take(search.PerPage);

            var response = new PagedResponse<TDto>
            {
                CurrentPage = search.Page,
                PerPage = search.PerPage,
                TotalCount = query.Count(),
                Data = mapper.Map<IEnumerable<TDto>>(skipped)
            };

            return response;
        }
    }
}
