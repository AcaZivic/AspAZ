using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Domain
{
    public class Customer : Entity
    {
        [AllowNull]
        public string? Name { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string StreetAddress { get; set; }
        [AllowNull]
        public int? TaxID { get; set; }

        public virtual ICollection<Cart> Carts { get; set; } = new HashSet<Cart>();

    }
}
