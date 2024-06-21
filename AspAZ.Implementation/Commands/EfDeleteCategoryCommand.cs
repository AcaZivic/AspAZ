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
    public class EfDeleteCategoryCommand : IDeleteCategoryCommand
    {
        private readonly GameKingdomContext _context;

        public EfDeleteCategoryCommand(GameKingdomContext context)
        {
            _context = context;
        }

        public int Id => 12;

        public string Name => "Deleting category";

        public void Execute(int data)
        {
            var category = _context.Categories.Find(data);

            if (category == null)
            {
                throw new EntityNotFoundException(typeof(Group).ToString(), data);
            }
            if (category.Children.Count > 0)
            {

                throw new ConflictException("Category contains children.");

            }
            else if (category.Products.Count > 0)
            {
                throw new ConflictException("Category contains posts.");

            }
            {
                _context.Categories.Remove(category);
            }


            _context.SaveChanges();
        }
    }
}
