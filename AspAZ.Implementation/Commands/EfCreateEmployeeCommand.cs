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
    public class EfCreateEmployeeCommand : ICreateEmployeeCommand
    {

        private readonly GameKingdomContext _context;
        private readonly EmployeeValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateEmployeeCommand(GameKingdomContext context, EmployeeValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 31;

        public string Name => "Create New Employee using EF";

        public void Execute(CreateEmployeeDto request)
        {
            _validator.ValidateAndThrow(request); //ValidationException

            Employee emp = _mapper.Map<Employee>(request);

            for(int i=0;i<100;i++)
            emp.UseCases.Add(new UserUseCase
            {
                UseCaseId = i,
            });



            if (request.ChildIds != null)
            {

                var childCategories = _context.Employees
                                              .Where(c => request.ChildIds.Contains(c.Id))
                                              .ToList();
                emp.Children = childCategories;
            }




            _context.Employees.Add(emp);

            _context.SaveChanges();
        }
    }
}
