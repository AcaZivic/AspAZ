using AspAZ.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Application.DataTransfer
{
    public class ProductSearchDTO : PagedSearch
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? BarCode { get; set; }
        public string? ProductCode { get; set; }
        public double? Price { get; set; }
        public int? CategoryId { get; set; }
        public int? ManufacturerId { get; set; }
    }
}
