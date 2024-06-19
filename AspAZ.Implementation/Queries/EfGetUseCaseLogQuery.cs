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
    public class EfGetUseCaseLogQuery : IGetUseCaseLogQuery
    {

        private readonly GameKingdomContext _context;

        public EfGetUseCaseLogQuery(GameKingdomContext context)
        {
            _context = context;
        }

        public int Id => 101;

        public string Name => "UseCaseLog Search";

        public PagedResponse<Application.DataTransfer.UseCaseLogDTO> Execute(UseCaseLogSearchDTO search)
        {
            var query = _context.UseCaseLogs.AsQueryable();

            if (!string.IsNullOrEmpty(search.Username) || !string.IsNullOrWhiteSpace(search.Username))
            {
                query = query.Where(x => x.Username.ToLower().Contains(search.Username.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.UseCaseName) || !string.IsNullOrWhiteSpace(search.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseName.ToLower()));
            }
            if (search.DateFrom != null)
            {
                query = query.Where(x=>x.ExecutedAt > search.DateFrom);
            }
            if (search.DateTo != null)
            {
                query = query.Where(x => x.ExecutedAt < search.DateTo);
            }



            var skipCount = search.PerPage * (search.Page - 1);

           
            var reponse = new PagedResponse<Application.DataTransfer.UseCaseLogDTO>
            {
                CurrentPage = search.Page,
                PerPage = search.PerPage,
                TotalCount = query.Count(),
                Data = query.Skip(skipCount).Take(search.PerPage).Select(x => new Application.DataTransfer.UseCaseLogDTO
                {
                    Id = x.Id,
                    ExecutedAt = x.ExecutedAt,
                    UseCaseName = x.UseCaseName,
                    UseCaseData = x.UseCaseData,
                    Username = x.Username
                }).ToList()
            };

            return reponse;
        }
    }
}
