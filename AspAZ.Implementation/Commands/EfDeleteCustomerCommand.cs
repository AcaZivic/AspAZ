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
    public class EfDeleteCustomerCommand : IDeleteCustomerCommand
    {
        private readonly GameKingdomContext _context;

        public EfDeleteCustomerCommand(GameKingdomContext context)
        {
            _context = context;
        }

        public int Id => 30;

        public string Name => "Deleting customer";

        public void Execute(int data)
        {
            var cust = _context.Products.Find(data);

            if (cust == null)
            {
                throw new EntityNotFoundException(typeof(Customer).ToString(), data);
            }
            cust.DeletedAt = DateTime.Now;
            cust.IsDeleted = true;
            cust.isActive = false;


            _context.SaveChanges();
        }
    }
}
