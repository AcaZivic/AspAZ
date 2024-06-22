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
    public class CustomerValidator : AbstractValidator<CreateCustomerDTO>
    {
        private readonly GameKingdomContext _context;
        public CustomerValidator(GameKingdomContext context)
        {
            _context = context;

            RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("FirstName is required")
            .MinimumLength(3)
            .WithMessage("FirstName minimum length is 3");


            RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("LastName is required")
            .MinimumLength(3)
            .WithMessage("LastName minimum length is 3");


            RuleFor(x => x.Name)
            .MinimumLength(3)
            .When(x=>x.Name!=null)
            .WithMessage("LastName minimum length is 3");


            RuleFor(x => x.TaxID)
            .GreaterThan(100000000)
            .When(x => x.TaxID != null)
            .WithMessage("TaxId must be greather than 100000000");


        }
    }
}
