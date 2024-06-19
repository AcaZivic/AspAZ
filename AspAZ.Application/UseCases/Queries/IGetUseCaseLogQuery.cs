using AspAZ.Application.DataTransfer;
using AspAZ.Application.DTO;
using AspAZ.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Application.UseCases.Queries
{
    public interface IGetUseCaseLogQuery : IQuery<UseCaseLogSearchDTO, PagedResponse<Application.DataTransfer.UseCaseLogDTO>>
    {
    }
}
