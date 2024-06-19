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
    public class GroupUpdateValidator : AbstractValidator<GroupUpdateDTO>
    {
        public GroupUpdateValidator(GameKingdomContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Group must have name")
                .Must((g,name) => !context.GroupEmps.Any(m => m.Name == name && m.Id != g.Id))
                .WithMessage(g => $"Group with the name of {g.Name} already exists in database.");
        }
    }
}
