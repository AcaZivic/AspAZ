using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Domain
{
    public class ProductProperty
    {
        public int ProductId { get; set; }
        public int PropertyId { get; set; }
        public string Value { get; set; }

        public virtual Product Product { get; set; }
        public virtual Property Property { get; set; }

    }
}
