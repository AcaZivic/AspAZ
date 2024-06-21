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
    public class EfUpdatePropertyCommand : IUpdatePropertyCommand
    {
        private readonly GameKingdomContext _context;
        private readonly PropertyUpdateValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdatePropertyCommand(GameKingdomContext context, PropertyUpdateValidator puv, IMapper mapper)
        {
            _context = context;
            _validator = puv;
            _mapper = mapper;
        }

        public int Id => 8;

        public string Name => "Updating property";

        public void Execute(PropertyUpdateDTO data)
        {
            var prop = _context.Properties.Find(data.Id);

            if (prop == null)
            {
                throw new EntityNotFoundException(typeof(Property).ToString(), data.Id);
            }
            _validator.ValidateAndThrow(data); //ValidationException

            _mapper.Map(data,prop);


            _context.SaveChanges();
        }
    }
}
