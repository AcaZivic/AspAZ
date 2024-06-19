using AspAZ.Application.Exceptions;
using AspAZ.Application.UseCases.Commands;
using AspAZ.DataAccess;
using AspAZ.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AspAZ.Implementation.Commands
{
    public class EfDeleteGroupCommand : IDeleteGroupCommand
    {
        private readonly GameKingdomContext _context;

        public EfDeleteGroupCommand(GameKingdomContext context)
        {
            _context = context;
        }

        public int Id => 5;

        public string Name => "Deleting group";

        public void Execute(int data)
        {
            var group = _context.GroupEmps.Find(data);

            if (group == null)
            {
                throw new EntityNotFoundException(typeof(Group).ToString(), data);
            }
            if (group.Employees.Count > 0)
            {
                group.DeletedAt = DateTime.Now;
                group.IsDeleted = true;
                group.isActive = false;
            }
            else
            {
                _context.GroupEmps.Remove(group);
            }


            _context.SaveChanges();
        }
    }
}
