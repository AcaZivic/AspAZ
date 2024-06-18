using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Domain
{
    public class RetailShop : NamedEntity
    {
        public string Address { get; set; }
        public string AddressNum { get; set; }
        public string City { get; set; }
        public string Telephone { get; set; }

        public virtual ICollection<ShopStorage> ShopStorages { get; set; } = new HashSet<ShopStorage>();

        public virtual ICollection<Cart> Carts { get; set; } = new HashSet<Cart>();

    }
}
