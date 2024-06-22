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
    public class EfDeleteCartCommand : IDeleteCartCommand
    {
        private readonly GameKingdomContext _context;

        public EfDeleteCartCommand(GameKingdomContext context)
        {
            _context = context;
        }

        public int Id => 40;

        public string Name => "Deleting cart";

        public void Execute(int data)
        {
            var pro = _context.Carts.Find(data);

            if (pro == null)
            {
                throw new EntityNotFoundException(typeof(Product).ToString(), data);
            }
                pro.DeletedAt = DateTime.Now;
                pro.IsDeleted = true;
                pro.isActive = false;


            _context.SaveChanges();
        }
    }
}
