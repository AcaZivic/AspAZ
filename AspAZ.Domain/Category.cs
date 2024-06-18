using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Domain
{
    public class Category : NamedEntity
    {
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public virtual ICollection<Category> Children { get; set; } = new HashSet<Category>();
        public virtual ICollection<PropertyCategory> PropertyCategories { get; set; } = new HashSet<PropertyCategory>();
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();

        public virtual Category Parent { get; set; }
    }
}
