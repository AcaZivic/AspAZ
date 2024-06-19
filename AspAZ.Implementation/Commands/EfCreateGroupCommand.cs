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
    public class EfCreateGroupCommand : ICreateGroupCommand
    {

        private readonly GameKingdomContext _context;
        private readonly GroupValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateGroupCommand(GameKingdomContext context, GroupValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 4;

        public string Name => "Create New GroupEmp using EF";

        public void Execute(GroupDTO request)
        {
            _validator.ValidateAndThrow(request); //ValidationException

            var group = _mapper.Map<GroupEmp>(request);

            _context.GroupEmps.Add(group);

            _context.SaveChanges();
        }
    }
}
