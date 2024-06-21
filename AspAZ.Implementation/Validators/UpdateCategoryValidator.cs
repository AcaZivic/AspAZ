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
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
    {
        private readonly GameKingdomContext _context;
        public UpdateCategoryValidator(GameKingdomContext context)
        {
            _context = context;
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Category name is required")
                .MinimumLength(3)
                .WithMessage("Minimal number of characters is 3.")
                .Must((dto, n) => !context.Categories.Any(c => c.Name == n && dto.Id != c.Id))
                .WithMessage("Category name must be unique");

            RuleFor(x => x.ParentId)
                .Must(CategoryExistsWhenNotNull)
                .WithMessage("Parent id doesn't exist.")
                 .Must(ParentIdIsValid)
                 .When(x => x.ParentId.HasValue)
                 .WithMessage("Invalid parent id.");

            RuleFor(x => x.ChildIds).Must(AllChildrenExist).WithMessage("Not all child categories exist in database.");
            RuleFor(x => x.Properties).Must(AllPropertiesExist).WithMessage("Not all child properties exist in database.");

        }

        private bool ParentIdIsValid(UpdateCategoryDto dto, int? parentId)
        {

            if (parentId == dto.Id)
            {
                return false;
            }

            return _context.Categories.Any(x => x.Id == parentId && x.isActive);
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

        private bool AllChildrenExist(UpdateCategoryDto dto, IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any())
            {
                return true;
            }
            if (ids.Contains(dto.Id))
            {
                return false;
            }

            int activeChilds = _context.Categories.Count(x => x.isActive && ids.Contains(x.Id));
            return activeChilds == ids.Count();
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
