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
    public class PriceListValidator : AbstractValidator<CreatePriceListDTO>
    {
        public PriceListValidator(GameKingdomContext context)
        {
            RuleFor(x => x.Price).GreaterThan(5);
            RuleFor(x => x.DateFrom).Must((ob, i) => ob.DateFrom < ob.DateTo)
                .When(x => x.DateTo != null);
            //RuleFor(x=>x.DateFrom).LessThan(x => x.DateTo);
            //RuleFor(x => x.DateTo).GreaterThan(x => x.DateFrom);
        }
    }
}
