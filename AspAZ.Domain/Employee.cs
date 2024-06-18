using AspYt.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Domain
{
    public class Employee : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get;set; }
        public string Email { get; set; }
        public int? ParentId { get; set; }
        public virtual ICollection<Employee> Children { get; set; } = new HashSet<Employee>();
        public int GroupEmpId { get; set; }
        public GroupEmp GroupEmp { get; set; }

        public virtual ICollection<Cart> Carts { get; set; } = new HashSet<Cart>();
        public virtual ICollection<UserUseCase> UseCases { get; set; } = new HashSet<UserUseCase>();


        public virtual Employee Parent { get; set; }
    }
}
