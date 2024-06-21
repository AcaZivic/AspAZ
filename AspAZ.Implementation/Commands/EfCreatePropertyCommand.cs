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
    public class EfCreatePropertyCommand : ICreatePropertyCommand
    {

        private readonly GameKingdomContext _context;
        private readonly PropertyValidator _validator;
        private readonly IMapper _mapper;

        public EfCreatePropertyCommand(GameKingdomContext context, PropertyValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 7;

        public string Name => "Create New Property using EF";

        public void Execute(PropertyDTO request)
        {
            _validator.ValidateAndThrow(request); //ValidationException

            var property = _mapper.Map<Property>(request);

            _context.Properties.Add(property);

            _context.SaveChanges();
        }
    }
}
