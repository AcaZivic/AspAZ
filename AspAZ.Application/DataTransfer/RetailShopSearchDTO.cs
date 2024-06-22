using AspAZ.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Application.DataTransfer
{
    public class RetailShopSearchDTO : PagedSearch
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Telephone { get; set; }
    }
}
