using AspAZ.DataAccess;
using AspAZ.DataTransfer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Implementation.Validators
{
    public class ManufacturerValidator : AbstractValidator<ManufacturerDTO>
    {
        public ManufacturerValidator(GameKingdomContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Manufacturer must have name")
                .Must(name => !context.Manufacturers.Any(m => m.Name == name))
                .WithMessage("Manufacturer name must be unique");
        }
    }
}
