using AspAZ.Application.UseCases.Commands;
using AspAZ.DataAccess;
using AspAZ.DataTransfer;
using AspAZ.Domain;
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
    public class EfCreatePriceListCommand : ICreatePriceListCommand
    {

        private readonly GameKingdomContext _context;
        private readonly PriceListValidator _validator;
        private readonly IMapper _mapper;

        public EfCreatePriceListCommand(GameKingdomContext context, PriceListValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 15;

        public string Name => "Create New PriceList using EF";

        public void Execute(CreatePriceListDTO request)
        {
            _validator.ValidateAndThrow(request); //ValidationException

            var pl = _mapper.Map<PriceList>(request);

            _context.PriceLists.Add(pl);

            _context.SaveChanges();
        }
    }
}
