using AspAZ.DataAccess;
using AspAZ.DataTransfer;
using AspYt.Application.DTO;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Implementation.Validators
{
    public class EmployeeUpdateValidator : AbstractValidator<UpdateEmployeeDto>
    {
        private readonly GameKingdomContext _context;
        public EmployeeUpdateValidator(GameKingdomContext context)
        {
            _context = context;

            CascadeMode = CascadeMode.StopOnFirstFailure;


            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("FirstName name is required")
                .MinimumLength(3)
                .WithMessage(" Minimal number of characters FirstName is 3.");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("LastName name is required")
                .MinimumLength(3)
                .WithMessage(" Minimal number of characters LastName is 3.");
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username name is required")
                .MinimumLength(6)
                .WithMessage(" Minimal number of characters Username is 6.")
                .Must((dto,name) => !_context.Employees.Any(m => m.Username == name && m.Id != dto.Id))
                .WithMessage("Username name must be unique");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email name is required")
                .MinimumLength(11)
                .WithMessage(" Minimal number of characters Email is 11.")
                .Must((dto,name) => !_context.Employees.Any(m => m.Email == name && m.Id!=dto.Id))
                .WithMessage("Email name must be unique");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password  is required")
                .MinimumLength(12)
                .WithMessage(" Minimal number of characters Password is 12.")
                .Must((dto, name) => !_context.Employees.Any(m => m.Password == name && m.Id != dto.Id))
                .WithMessage("Password name must be unique");

            RuleFor(x => x.ParentId).Must(EmployeeExistsWhenNotNull)
                                    .WithMessage("Parent id doesn't exist.");

            RuleFor(x => x.ChildIds)
                .Must(AllChildrenExist)
                .WithMessage("Not all child categories exist in database.")
                .Must(AllUniqueChildrenExist)
                .WithMessage("Duplicate childs are not allowed");


            RuleFor(x => x.GroupEmpId)
               .Must(x => x > 0)
               .WithMessage("GroupEmpId  is required")
               .Must(GroupExist)
               .WithMessage("Group doesn't exist.");

        }

        private bool GroupExist(int arg)
        {
            return _context.GroupEmps.Any(m => m.Id == arg);
        }

        private bool AllChildrenExist(IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any())
            {
                return true;
            }

            int activeChilds = _context.Employees.Count(x => x.isActive && ids.Contains(x.Id));
            return activeChilds == ids.Count();
        }


        private bool EmployeeExistsWhenNotNull(int? parentId)
        {
            if (!parentId.HasValue)
            {
                return true;
            }

            return _context.Employees.Any(x => x.Id == parentId && x.isActive);
        }
        private bool AllUniqueChildrenExist(CreateEmployeeDto dto,IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any())
            {
                return true;
            }
            return ids.Distinct().Count() == dto.ChildIds.Count();
        }
    }
}
