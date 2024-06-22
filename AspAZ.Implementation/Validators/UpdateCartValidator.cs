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
    public class UpdateCartValidator : AbstractValidator<CreateCartDto>
    {
        private readonly GameKingdomContext _context;
        public UpdateCartValidator(GameKingdomContext context)
        {
            _context = context;
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.RetailShopId)
                .NotEmpty()
                .WithMessage("RetailShopId  is required")
                .Must(RetailShopExist)
                .WithMessage("RetailShopId doesn't exist");
            RuleFor(x => x.EmployeeId)
                .NotEmpty()
                .WithMessage("EmployeeId  is required")
                .Must(EmployeeExist)
                .WithMessage("EmployeeId doesn't exist");
            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .WithMessage("CustomerId  is required")
                .Must(CustomerExist)
                .WithMessage("CustomerId doesn't exist");


            RuleFor(x => x.ProductCarts)
                .NotEmpty()
                .WithMessage("Cart must have at least one product")
                .Must(AllUniqueProductExist)
                .WithMessage("Duplicate products are not allowed")
                .DependentRules(() =>
                 {
                     RuleForEach(x => x.ProductCarts).SetValidator
                         (new CartProductValidator(_context));
                 });

        }

        private bool AllProductsExist(IEnumerable<ProductCartDto> ids)
        {
            if (ids == null || !ids.Any())
            {
                return true;
            }

            var lst = ids.Select(x => x.ProductId).ToList();
            int activeChilds = _context.Products.Count(x => x.isActive && lst.Contains(x.Id));
            return activeChilds == ids.Count();
        }
        private bool AllUniqueProductExist(CreateCartDto dto, IEnumerable<ProductCartDto> ids)
        {
            if (ids == null || !ids.Any())
            {
                return true;
            }
            var lst = ids.Select(x => x.ProductId).ToList();

            return lst.Distinct().Count() == dto.ProductCarts.Count();
        }


        private bool RetailShopExist(int id)
        {

            return _context.RetailShops.Any(x => x.Id == id);
        }

        private bool EmployeeExist(int id)
        {

            return _context.Employees.Any(x => x.Id == id);
        }

        private bool CustomerExist(int id)
        {

            return _context.Customers.Any(x => x.Id == id);
        }
    }
}
