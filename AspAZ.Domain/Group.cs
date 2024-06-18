using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Domain
{
    public class GroupEmp : NamedEntity
    {

        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

    }
}
