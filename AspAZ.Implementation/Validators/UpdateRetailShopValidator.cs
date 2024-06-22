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
    public class UpdateRetailShopValidator : AbstractValidator<UpdateRetailShopDTO>
    {
        private readonly GameKingdomContext _context;
        public UpdateRetailShopValidator(GameKingdomContext context)
        {
            _context = context;


            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MinimumLength(3)
                .WithMessage("Minimal number of characters is 3.")
                .Must((dto,name) => !_context.RetailShops.Any(m => m.Name == name && dto.Id!=m.Id))
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
                 .Must((dto, tel) => !_context.RetailShops.Any(m => m.Telephone == tel && dto.Id != m.Id))
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


        private bool AllUniqueProductsExist(IEnumerable<ShopProductDto> ids)
        {

            int prop = ids.Select(x => x.ProductId).Distinct().Count();
            return prop == ids.Count();
        }
    }

        
    }

