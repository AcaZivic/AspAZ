using AspAZ.Application.DataTransfer;

namespace AspAZ.DataTransfer
{
    public class PriceListSearchDTO : PagedSearch
    {
        public double MinPrice { get; set; }
        public bool? Active { get; set; }

    }
}
