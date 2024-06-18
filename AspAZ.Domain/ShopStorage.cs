using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Domain
{
    public class ShopStorage : NamedEntity
    {
        public int RetailShopId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime lastTimeSupply { get; set; }

        public virtual RetailShop RetailShop { get; set; }
        public virtual Product Product { get; set; }
    }
}
