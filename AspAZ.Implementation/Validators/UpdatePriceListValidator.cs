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
    public class UpdatePriceListValidator : AbstractValidator<UpdatePriceListDTO>
    {
        public UpdatePriceListValidator(GameKingdomContext context)
        {
            RuleFor(x => x.AddDateFrom).Must((ob, i) => ob.AddDateFrom < ob.DateTo)
                .When(x => x.DateTo != null);
            //RuleFor(x=>x.DateFrom).LessThan(x => x.DateTo);
            //RuleFor(x => x.DateTo).GreaterThan(x => x.DateFrom);
        }
    }
}
