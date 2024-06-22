using AspAZ.DataAccess;
using AspAZ.DataTransfer;
using AspYt.Application.DTO;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AspAZ.Implementation.Validators
{
    public class RetailShopValidator : AbstractValidator<CreateRetailShopDTO>
    {
        private readonly GameKingdomContext _context;
        public RetailShopValidator(GameKingdomContext context)
        {
            _context = context;


            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MinimumLength(3)
                .WithMessage("Minimal number of characters is 3.")
                .Must(name => !_context.RetailShops.Any(m => m.Name == name))
                .WithMessage("RetailShop name must be unique");


            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("Address name is required")
                .MinimumLength(3)
                .WithMessage("Minimal number of characters is 3.");

            RuleFor(x => x.AddressNum)
                .NotEmpty()
                .WithMessage("Address number is required");


            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("City name is required")
                .MinimumLength(3)
                .WithMessage("Minimal number of characters is 3.");


            RuleFor(x => x.Telephone)
                 .NotEmpty()
                 .WithMessage("Telephone  is required")
                 .MinimumLength(8)
                 .WithMessage("Minimal number of characters is 8.")
                 .Must(tel => !_context.RetailShops.Any(m => m.Telephone == tel))
                .WithMessage("Telephone must be unique");

            RuleFor(x => x.ShopProducts)
                .NotEmpty()
                .WithMessage("ShopProducts  is required")
                .Must(AllUniqueProductsExist)
                .WithMessage("There is duplicate product")
                //.Must(AllProductsExist)
                //.WithMessage("Not all child properties exist in database.")
                .DependentRules(() =>
                 {
                     RuleForEach(x => x.ShopProducts).SetValidator
                         (new RetailShopProductsValidator(_context));
                 });




        }

        //private bool AllProductsExist(IEnumerable<ShopProductDto> ids)
        //{
        //    if (ids == null || !ids.Any())
        //    {
        //        return true;
        //    }
        //    var listIdent =ids.Select(x=>x.ProductId).ToList();

        //    int prop = _context.Products.Count(x => x.isActive && listIdent.Contains(x.Id));
        //    return prop == ids.Count();
        //}

        private bool AllUniqueProductsExist(IEnumerable<ShopProductDto> ids)
        {

            int prop = ids.Select(x=>x.ProductId).Distinct().Count();
            return prop == ids.Count();
        }


}
}
