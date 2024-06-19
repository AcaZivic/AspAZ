using AspAZ.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Application.DataTransfer
{
    public class UseCaseLogSearchDTO : PagedSearch
    {
        public string? UseCaseName { get; set; }
        public string? Username { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
