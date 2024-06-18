using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Domain
{
    public class Customer : NamedEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string StreetAddress { get; set; }
        public int TaxID { get; set; }

        public virtual ICollection<Cart> Carts { get; set; } = new HashSet<Cart>();

    }
}
