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
    public class GroupValidator : AbstractValidator<GroupDTO>
    {
        public GroupValidator(GameKingdomContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Group must have name")
                .Must(name => !context.GroupEmps.Any(m => m.Name == name))
                .WithMessage("Group name must be unique");
        }
    }
}
