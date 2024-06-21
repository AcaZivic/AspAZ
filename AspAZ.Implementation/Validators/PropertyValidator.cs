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
    public class PropertyValidator : AbstractValidator<PropertyDTO>
    {
        public PropertyValidator(GameKingdomContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Property must have name")
                .Must(name => !context.Properties.Any(m => m.Name == name))
                .WithMessage("Property name must be unique");
        }
    }
}
