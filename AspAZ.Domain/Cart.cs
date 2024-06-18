using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Domain
{
    public class Cart : Entity
    {

        public string RetailShopName { get; }

        public RetailShop RetailShop { get;set; }
        public int RetailShopId { get; set; }

        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public virtual ICollection<ProductCart> ProductCarts { get; set; } = new HashSet<ProductCart>();


        public double? TotalPrice { get; set; } 

        public DateTime? dateRealization { get; set; }

    }
}
