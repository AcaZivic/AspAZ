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
    public interface IGetGroupQuery : IQuery<GroupSearchDTO, PagedResponse<GroupDTO>>
    {
    }
}
