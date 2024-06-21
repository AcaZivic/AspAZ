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
    public class EfGetCategoryQuery : IGetCategoryQuery
    {
        private readonly GameKingdomContext context;
        private readonly IMapper _mapper;

        public EfGetCategoryQuery(GameKingdomContext context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }

        public int Id => 104;

        public string Name => "Category search.";

        public PagedResponse<CategoryDto> Execute(CategorySearchDTO search)
        {
            var query = context.Categories.AsQueryable();

            //var x =query.Select(x => x.Children).ToList();

            if(!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            }

            if (search.HasChlidren != null)
            {
                query = query.Where(x => x.Children.Count()>0);

            }
            if (!string.IsNullOrEmpty(search.Description) || !string.IsNullOrWhiteSpace(search.Description))
            {
                query = query.Where(x => x.Description.ToLower().Contains(search.Description.ToLower()));
            }
            if (search.ParentId != null)
            {
                query = query.Where(x=>x.ParentId==search.ParentId);
            }

            var arr = query.Paged<CategoryDto, Domain.Category>(search, _mapper);
            var arrChld = context.Categories.AsQueryable();

            foreach (var item in arr.Data) {
                var tempArr = arrChld.Where(x => x.Id == item.Id).Select(x => x.Children);
                var dat = tempArr.Select(x => x.Select(it=> new CategoryDto
                {
                    Id = it.Id,
                    Name = it.Name,
                    Description = it.Description,
                })).First();
                item.Children = dat;
            }
            return arr;
        }
    }
}
