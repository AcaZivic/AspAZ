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
    public class EfDeletePropertyCommand : IDeletePropertyCommand
    {
        private readonly GameKingdomContext _context;

        public EfDeletePropertyCommand(GameKingdomContext context)
        {
            _context = context;
        }

        public int Id => 9;

        public string Name => "Deleting property";

        public void Execute(int data)
        {
            var temp = _context.Properties.Find(data);

            if (temp == null)
            {
                throw new EntityNotFoundException(typeof(Property).ToString(), data);
            }
            if (temp.ProductProperties.Count > 0)
            {
                temp.DeletedAt = DateTime.Now;
                temp.IsDeleted = true;
                temp.isActive = false;
            }
            else
            {
                _context.Properties.Remove(temp);
            }


            _context.SaveChanges();
        }
    }
}
