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
    public class EfDeletePriceListCommand : IDeletePriceListCommand
    {
        private readonly GameKingdomContext _context;

        public EfDeletePriceListCommand(GameKingdomContext context)
        {
            _context = context;
        }

        public int Id => 18;

        public string Name => "Deleting price list";

        public void Execute(int data)
        {
            var pl = _context.PriceLists.Find(data);

            if (pl == null)
            {
                throw new EntityNotFoundException(typeof(PriceList).ToString(), data);
            }
            if (pl.Product !=null)
            {
                pl.DeletedAt = DateTime.Now;
                pl.IsDeleted = true;
                pl.isActive = false;
            }
            else
            {
                _context.PriceLists.Remove(pl);
            }


            _context.SaveChanges();
        }
    }
}
