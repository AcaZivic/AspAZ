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
    public class EfUpdateGroupCommand : IUpdateGroupCommand
    {
        private readonly GameKingdomContext _context;
        private readonly GroupUpdateValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateGroupCommand(GameKingdomContext context,GroupUpdateValidator guv, IMapper mapper)
        {
            _context = context;
            _validator = guv;
            _mapper = mapper;
        }

        public int Id => 6;

        public string Name => "Updating group";

        public void Execute(GroupUpdateDTO data)
        {
            var group = _context.GroupEmps.Find(data.Id);

            if (group == null)
            {
                throw new EntityNotFoundException(typeof(GroupEmp).ToString(), data.Id);
            }
            _validator.ValidateAndThrow(data); //ValidationException

            var groupObj = _mapper.Map<GroupEmp>(data);

            _context.GroupEmps.Add(groupObj);

            _context.SaveChanges();
        }
    }
}
