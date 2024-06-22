using AspAZ.Application.Exceptions;
using AspAZ.Application.UseCases.Commands;
using AspAZ.DataAccess;
using AspAZ.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AspAZ.Implementation.Commands
{
    public class EfDeleteEmployeeCommand : IDeleteEmployeeCommand
    {
        private readonly GameKingdomContext _context;

        public EfDeleteEmployeeCommand(GameKingdomContext context)
        {
            _context = context;
        }

        public int Id => 31;

        public string Name => "Deleting employee";

        public void Execute(int data)
        {
            var cust = _context.Employees.Find(data);

            if (cust == null)
            {
                throw new EntityNotFoundException(typeof(Employee).ToString(), data);
            }
            cust.DeletedAt = DateTime.Now;
            cust.IsDeleted = true;
            cust.isActive = false;


            _context.SaveChanges();
        }
    }
}
