using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Domain
{
    public class ProductCart
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Cart Cart { get; set; }

        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDescription { get; set; }

    }
}
