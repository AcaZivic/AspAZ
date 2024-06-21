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
    public class CategoryValidator : AbstractValidator<CreateCategoryDto>
    {
        private readonly GameKingdomContext _context;
        public CategoryValidator(GameKingdomContext context)
        {
            _context = context;
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Category name is required")
                .MinimumLength(3)
                .WithMessage("Minimal number of characters is 3.")
                .Must(name => !_context.Categories.Any(m => m.Name == name))
                .WithMessage("Category name must be unique");

            RuleFor(x => x.ParentId).Must(CategoryExistsWhenNotNull)
                                    .WithMessage("Parent id doesn't exist.");

            RuleFor(x => x.ChildIds).Must(AllChildrenExist).WithMessage("Not all child categories exist in database.");
            RuleFor(x => x.Properties).Must(AllPropertiesExist).WithMessage("Not all child properties exist in database.");

        }

        private bool AllChildrenExist(IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any())
            {
                return true;
            }

            int activeChilds = _context.Categories.Count(x => x.isActive && ids.Contains(x.Id));
            return activeChilds == ids.Count();
        }

        private bool AllPropertiesExist(IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any())
            {
                return true;
            }

            int prop = _context.Properties.Count(x => x.isActive && ids.Contains(x.Id));
            return prop == ids.Count();
        }

        private bool CategoryExistsWhenNotNull(int? parentId)
        {
            if (!parentId.HasValue)
            {
                return true;
            }

            return _context.Categories.Any(x => x.Id == parentId && x.isActive);
        }
    }
}
