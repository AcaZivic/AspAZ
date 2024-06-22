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
    public class EfDeleteRetailShopCommand : IDeleteRetailShopCommand
    {
        private readonly GameKingdomContext _context;

        public EfDeleteRetailShopCommand(GameKingdomContext context)
        {
            _context = context;
        }

        public int Id => 21;

        public string Name => "Deleting retail shop";

        public void Execute(int data)
        {
            var temp = _context.RetailShops.Find(data);

            if (temp == null)
            {
                throw new EntityNotFoundException(typeof(RetailShop).ToString(), data);
            }
            temp.DeletedAt = DateTime.Now;
            temp.IsDeleted = true;
            temp.isActive = false;


            _context.SaveChanges();
        }
    }
}
