using AspAZ.Application.Exceptions;
using AspAZ.Application.UseCases.Commands;
using AspAZ.DataAccess;
using AspAZ.DataTransfer;
using AspAZ.Domain;
using AspAZ.Implementation.Profiles;
using AspAZ.Implementation.Validators;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AspAZ.Implementation.Commands
{
    public class EfUpdateCustomerCommand : IUpdateCustomerCommand
    {
        private readonly GameKingdomContext _context;
        private readonly CustomerValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateCustomerCommand(GameKingdomContext context, CustomerValidator guv, IMapper mapper)
        {
            _context = context;
            _validator = guv;
            _mapper = mapper;
        }

        public int Id => 29;

        public string Name => "Updating customer";

        public void Execute(UpdateCustomerDTO data)
        {
            var cust = _context.Customers.Find(data.Id);

            if (cust == null)
            {
                throw new EntityNotFoundException(typeof(Customer).ToString(), data.Id);
            }
            _validator.ValidateAndThrow(data); //ValidationException


            _mapper.Map(data, cust);

            


            


            _context.SaveChanges();
        }
    }
}
