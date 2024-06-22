using AspAZ.Application.UseCases.Commands;
using AspAZ.DataAccess;
using AspAZ.DataTransfer;
using AspAZ.Domain;
using AspAZ.Implementation.Validators;
using AspYt.Application.DTO;
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
    public class EfCreateCustomerCommand : ICreateCustomerCommand
    {

        private readonly GameKingdomContext _context;
        private readonly CustomerValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateCustomerCommand(GameKingdomContext context, CustomerValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 10;

        public string Name => "Create New Category using EF";

        public void Execute(CreateCustomerDTO request)
        {
            _validator.ValidateAndThrow(request); //ValidationException

            Customer customerToAdd =  _mapper.Map<Customer>(request);



            _context.Customers.Add(customerToAdd);

            _context.SaveChanges();
        }
    }
}
