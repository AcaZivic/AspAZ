using AspAZ.Domain;

namespace AspAZ.DataTransfer
{
    public class CreateRetailShopDTO 
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string AddressNum { get; set; }
        public string City { get; set; }
        public string Telephone { get; set; }

        public IEnumerable<ShopProductDto> ShopProducts { get; set; } = new HashSet<ShopProductDto>();
 
    }

    public class ShopProductDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime LastTimeSupply { get; set; }
    }
}
