using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Domain
{
    public class PropertyCategory 
    {
        public int PropertyId { get; set; }
        public int CategoryId { get; set; }

        public virtual Property Property { get; set; }
        public virtual Category Category { get; set; }

    }
}
