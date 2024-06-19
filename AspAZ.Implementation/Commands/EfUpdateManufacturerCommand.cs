using AspAZ.Application.Exceptions;
using AspAZ.Application.UseCases.Commands;
using AspAZ.DataAccess;
using AspAZ.DataTransfer;
using AspAZ.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AspAZ.Implementation.Commands
{
    public class EfUpdateManufacturerCommand : IUpdateManufacturerCommand
    {
        private readonly GameKingdomContext _context;

        public EfUpdateManufacturerCommand(GameKingdomContext context)
        {
            _context = context;
        }

        public int Id => 3;

        public string Name => "Updating manufacturer";

        public void Execute(ManufacturerUpdateDTO data)
        {
            var manufacturer = _context.Manufacturers.Find(data.Id);

            if (manufacturer == null)
            {
                throw new EntityNotFoundException(typeof(Manufacturer).ToString(), data.Id);
            }

            if (data.Description != null && data.Description!=manufacturer.Description)
            {
                manufacturer.ModifiedAt = DateTime.Now;
                manufacturer.Description = data.Description;

                _context.SaveChanges();
            }
        }
    }
}
