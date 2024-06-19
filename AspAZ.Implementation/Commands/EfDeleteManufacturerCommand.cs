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
    public class EfDeleteManufacturerCommand : IDeleteManufacturerCommand
    {
        private readonly GameKingdomContext _context;

        public EfDeleteManufacturerCommand(GameKingdomContext context)
        {
            _context = context;
        }

        public int Id => 2;

        public string Name => "Deleting manufacturer";

        public void Execute(int data)
        {
            var manufacturer = _context.Manufacturers.Find(data);

            if (manufacturer == null)
            {
                throw new EntityNotFoundException(typeof(Manufacturer).ToString(), data);
            }
            if (manufacturer.Products.Count > 0)
            {
                manufacturer.DeletedAt = DateTime.Now;
                manufacturer.IsDeleted = true;
                manufacturer.isActive = false;
            }
            else
            {
                _context.Manufacturers.Remove(manufacturer);
            }


            _context.SaveChanges();
        }
    }
}
