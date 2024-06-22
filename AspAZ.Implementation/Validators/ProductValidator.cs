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
using System.Xml;

namespace AspAZ.Implementation.Validators
{
    public class ProductValidator : AbstractValidator<CreateProductDTO>
    {
        private readonly GameKingdomContext _context;
        public ProductValidator(GameKingdomContext context)
        {
            _context = context;
            CascadeMode = CascadeMode.StopOnFirstFailure;


            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Product name is required")
                .MinimumLength(3)
                .WithMessage("Minimal number of characters is 3.")
                .Must(name => !_context.Products.Any(m => m.Name == name))
                .WithMessage("Product name must be unique");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required")
                .MinimumLength(20)
                .WithMessage("Minimal number of characters is 20.");
            RuleFor(x => x.BarCode)
                .NotEmpty()
                .WithMessage("BarCode is required")
                .MinimumLength(13)
                .WithMessage("BarCode lenght must be 13")
                .Must((dto,x)=>!_context.Products.Any(x=>x.BarCode==dto.BarCode))
                .WithMessage("BarCode must be unique");

            RuleFor(x => x.ProductCode)
                .NotEmpty()
                .WithMessage("ProductCode is required")
                .MinimumLength(6)
                .WithMessage("ProductCode lenght must be 6")
                .Must((dto, x) => !_context.Products.Any(x => x.ProductCode == dto.ProductCode))
                .WithMessage("ProductCode must be unique");

            RuleFor(x => x.PriceListId)
                .NotEmpty()
                .WithMessage("PriceList is required")
                .Must(PriceListExist)
                .WithMessage("PriceList doesn't exist ");

            RuleFor(x => x.ManufacturerId)
                .NotEmpty()
                .WithMessage("Manufacturer is required")
                .Must(ManufacturerExist)
                .WithMessage("Manufacturer doesn't exist ");

            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .WithMessage("Category is required")
                .Must(CategoryExist)
                .WithMessage("Category doesn't exist ");


            RuleFor(x => x.Properties)
                .Must(x => x.Any())
                 .WithMessage("Properties is required.")
                
                .DependentRules( () =>
                        RuleFor(x => x.Properties)
                        .Must(PropertyExist)
                        .WithMessage("Some property doesn't exist ")
                        .Must(ValueExist)
                         .WithMessage("Value is required")
                );

            



        }



        private bool PriceListExist(int id)
        {

            return _context.PriceLists.Any(x => x.Id == id && x.isActive);
        }
        private bool ManufacturerExist(int id)
        {
            var x = _context.Manufacturers.Find(id);
            return _context.Manufacturers.Any(x => x.Id == id && x.isActive);
        }
        private bool CategoryExist(int id)
        {

            return _context.Categories.Any(x => x.Id == id && x.isActive);
        }
        private bool PropertyExist(IEnumerable<ProductPropertyDTO> ids)
        {
            var lstProp =ids.Where(y => _context.Properties.Any(x => y.PropertyId == x.Id && x.isActive))
                                               .Count();
            return (lstProp == ids.Count());
        }

        private bool ValueExist(IEnumerable<ProductPropertyDTO> ids)
        {
            
            return !ids.Any(x => x.Value.Length == 0);
        }

    }
}
