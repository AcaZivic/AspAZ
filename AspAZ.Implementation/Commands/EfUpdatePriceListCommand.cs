using AspAZ.Application.Exceptions;
using AspAZ.Application.UseCases.Commands;
using AspAZ.DataAccess;
using AspAZ.DataTransfer;
using AspAZ.Domain;
using AspAZ.Implementation.Profiles;
using AspAZ.Implementation.Validators;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AspAZ.Implementation.Commands
{
    public class EfUpdatePriceListCommand : IUpdatePriceListCommand
    {
        private readonly GameKingdomContext _context;
        private readonly UpdatePriceListValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdatePriceListCommand(GameKingdomContext context, UpdatePriceListValidator guv, IMapper mapper)
        {
            _context = context;
            _validator = guv;
            _mapper = mapper;
        }

        public int Id => 16;

        public string Name => "Updating price list";

        public void Execute(UpdatePriceListDTO data)
        {
            var pl = _context.PriceLists.Find(data.Id);

            data.AddDateFrom = pl.DateFrom;
            if (pl == null)
            {
                throw new EntityNotFoundException(typeof(PriceList).ToString(), data.Id);
            }
            _validator.ValidateAndThrow(data); //ValidationException


            
            pl.DateTo = data.DateTo;


            _context.SaveChanges();
        }
    }
}
