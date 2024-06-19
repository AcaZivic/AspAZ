using AspAZ.Application.UseCases.Commands;
using AspAZ.DataAccess;
using AspAZ.DataTransfer;
using AspAZ.Domain;
using AspAZ.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AspAZ.Implementation.Commands
{
    public class EfCreateManufacturerCommand : ICreateManufacturerCommand
    {

        private readonly GameKingdomContext _context;
        private readonly ManufacturerValidator _validator;

        public EfCreateManufacturerCommand(GameKingdomContext context, ManufacturerValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 1;

        public string Name => "Create New Manufacturer using EF";

        public void Execute(ManufacturerDTO request)
        {
            _validator.ValidateAndThrow(request); //ValidationException

            var manufacturer = new Manufacturer
            {
                Name = request.Name,
                Description = request.Description,
            };

            _context.Manufacturers.Add(manufacturer);

            _context.SaveChanges();
        }
    }
}
