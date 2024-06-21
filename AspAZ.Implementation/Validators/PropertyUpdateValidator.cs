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
    public class PropertyUpdateValidator : AbstractValidator<PropertyUpdateDTO>
    {
        public PropertyUpdateValidator(GameKingdomContext context)
        {

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Property must have name")
                .Must((g,name) => !context.Properties.Any(m => m.Name == name && m.Id != g.Id))
                .WithMessage(g => $"Property with the name of {g.Name} already exists in database.");
        }
    }
}
