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
    public class RetailShopProductsValidator : AbstractValidator<ShopProductDto>
    {
        private readonly GameKingdomContext _context;
        public RetailShopProductsValidator(GameKingdomContext context)
        {
            _context = context;


            RuleFor(x => x.ProductId)
                .NotEmpty()
                .WithMessage("Product Id is required")
                .Must(ProductExist)
                .WithMessage("Product Id doesn't exist");

            RuleFor(x => x.Quantity)
               .NotEmpty()
               .WithMessage("Quantity  is required")
               .GreaterThan(0)
               .WithMessage("Quantity must be greater than 0");




        }

        private bool ProductExist(int arg)
        {
            return _context.Products.Any(x=>x.Id == arg);
        }
    }
}
