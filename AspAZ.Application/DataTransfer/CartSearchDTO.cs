using AspAZ.Application.DataTransfer;

namespace AspAZ.DataTransfer
{
    public class CartSearchDTO : PagedSearch
    {
        public int? RetailShopId { get; set; }
        public int? EmployeeId { get; set; }
        public int? CustomerId { get; set; }
        public int? MinProductPerCart { get; set; }

    }
}
