using AspAZ.Application.Exceptions;
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
    public class EfUpdateEmployeeCommand : IUpdateEmployeeCommand
    {

        private readonly GameKingdomContext _context;
        private readonly EmployeeUpdateValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateEmployeeCommand(GameKingdomContext context, EmployeeUpdateValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 11;

        public string Name => "Update  Category using EF";

        public void Execute(UpdateEmployeeDto request)
        {
            _validator.ValidateAndThrow(request); //ValidationException

            Employee emp = _context.Employees.Find(request.Id);

            if (emp == null)
            {
                throw new EntityNotFoundException(typeof(Employee).ToString(), request.Id);
            }

            _mapper.Map(request, emp);

            if (request.ChildIds != null)
            {

                var childCategories = _context.Employees
                                              .Where(c => request.ChildIds.Contains(c.Id))
                                              .ToList();
                emp.Children = childCategories;
            }





            _context.SaveChanges();
        }
    }
}
