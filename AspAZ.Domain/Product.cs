using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Domain
{
    public class Product : NamedEntity
    {
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public string BarCode { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<ProductProperty> ProductProperties { get; set; } = new HashSet<ProductProperty>();
        public virtual ICollection<ShopStorage> ShopStorages { get; set; } = new HashSet<ShopStorage>();
        public virtual ICollection<ProductCart> ProductCarts { get; set; } = new HashSet<ProductCart>();



        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        public virtual PriceList? PriceList { get; set; }
        public int PriceListId { get; set; }

    }
}
