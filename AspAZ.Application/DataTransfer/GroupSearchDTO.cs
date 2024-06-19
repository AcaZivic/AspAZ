using AspAZ.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Application.DataTransfer
{
    public class GroupSearchDTO : PagedSearch
    {
        public string? Name { get; set; }
        public int? MinNumberOfEmployees { get; set; }
    }
}
