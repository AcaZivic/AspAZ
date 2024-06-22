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
    public class EfGetEmployeeQuery : IGetEmployeeQuery
    {
        private readonly GameKingdomContext _context;
        private readonly IMapper _mapper;

        public EfGetEmployeeQuery(GameKingdomContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 118;

        public string Name => "Employee search.";

        public PagedResponse<EmployeeDTO> Execute(EmployeeSearchDTO search)
        {
            var query = _context.Employees.AsQueryable();

        if( !string.IsNullOrWhiteSpace(search.FirstName))
        {
            query = query.Where(x => x.FirstName.ToLower().Contains(search.FirstName.ToLower()));
        }
            if (!string.IsNullOrWhiteSpace(search.LastName))
            {
                query = query.Where(x => x.LastName.ToLower().Contains(search.LastName.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(search.Username))
            {
                query = query.Where(x => x.Username.ToLower().Contains(search.Username.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(search.Email))
            {
                query = query.Where(x => x.Email.ToLower().Contains(search.Email.ToLower()));
            }
            if (search.Id !=null)
            {
                query = query.Where(x => x.Id==search.Id);
            }
            if (search.GroupEmpId != null)
            {
                query = query.Where(x => x.GroupEmpId == search.GroupEmpId);
            }
            if (search.HasChlidren != null)
            {
                if(search.HasChlidren==true)
                    query = query.Where(x => x.Children.Count()>0);
                else
                    query = query.Where(x => x.Children.Count()==0);
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

            var arr = query.Paged<EmployeeDTO, Domain.Employee>(search, _mapper);
            var arrChld = _context.Employees.AsQueryable();

            foreach (var item in arr.Data)
            {
                var tempArr = arrChld.Where(x => x.Id == item.Id).Select(x => x.Children);
                var dat = tempArr.Select(x => x.Select(it => _mapper.Map<EmployeeDTO>(it))).First();
                item.Children = dat;

                if (item.ParentId > 0)
                {
                    var obj = arrChld.Where(x => item.ParentId == x.Id).First();
                    item.ParentName = obj.Username;
                }

                if (item.GroupEmpId > 0)
                 item.GroupName = _context.GroupEmps.First(x=>x.Id==item.GroupEmpId).Name;
            }
            
            return arr;
        }
    }
}
