using AspAZ.Application.DataTransfer;
using AspAZ.Application.DTO;
using AspAZ.DataTransfer;
using AspYt.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Application.UseCases.Queries
{
    public interface IGetCategoryQuery : IQuery<CategorySearchDTO, PagedResponse<CategoryDto>>
    {
    }
}
