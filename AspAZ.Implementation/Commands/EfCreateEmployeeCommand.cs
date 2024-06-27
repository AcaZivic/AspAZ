using AspAZ.Application.Email;
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
using System.Reflection;
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
        private readonly IEmailSender _emailSender;

        public EfCreateEmployeeCommand(GameKingdomContext context, EmployeeValidator validator, IMapper mapper, IEmailSender sender)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
            _emailSender = sender;
        }

        public int Id => 31;

        public string Name => "Create New Employee using EF";

        public void Execute(CreateEmployeeDto request)
        {
            _validator.ValidateAndThrow(request); //ValidationException

            Employee emp = _mapper.Map<Employee>(request);

            //for (int i = 0; i < 100; i++)
            //    emp.UseCases.Add(new UserUseCase
            //    {
            //        UseCaseId = i,
            //    });



            if (request.ChildIds != null)
            {

                var childCategories = _context.Employees
                                              .Where(c => request.ChildIds.Contains(c.Id))
                                              .ToList();
                emp.Children = childCategories;
            }




            _context.Employees.Add(emp);

            _context.SaveChanges();

            //_emailSender.Send(new SendEmailDTO
            //{
            //    Content ="<h1>Volim Mic</h1><p>Da li želite da mi budete žena?</p>",
            //    SendTo = "ljubenovicmilica24@gmail.com",
            //    Subject = "VAŽNA PORUKA"
            //});

            _emailSender.Send(new SendEmailDTO
            {
                Content = $"<h1>Kreiran novi nalog </h1><p>Kreiran je uspešno nalog sa username={request.Username}</p>",
                SendTo = request.Email,
                Subject = "Uspešna registracija"
            });
        }
    }
}
