using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Domain
{
    public class Property : NamedEntity
    {
        public string MeasureUnit { get; set; }

        public virtual ICollection<PropertyCategory> PropertyCategories { get; set; } = new HashSet<PropertyCategory>();
        public ICollection<ProductProperty> ProductProperties { get; set; } = new HashSet<ProductProperty>();


    }
}
