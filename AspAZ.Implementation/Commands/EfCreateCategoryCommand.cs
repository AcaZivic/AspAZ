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
    public class EfCreateCategoryCommand : ICreateCategoryCommand
    {

        private readonly GameKingdomContext _context;
        private readonly CategoryValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateCategoryCommand(GameKingdomContext context, CategoryValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 10;

        public string Name => "Create New Category using EF";

        public void Execute(CreateCategoryDto request)
        {
            _validator.ValidateAndThrow(request); //ValidationException

            Category categoryToAdd = new Category
            {
                Name = request.Name,
                ParentId = request.ParentId,
                Description = request.Description,
            };

            if (request.ChildIds != null)
            {

                var childCategories = _context.Categories
                                              .Where(c => request.ChildIds.Contains(c.Id))
                                              .ToList();
                categoryToAdd.Children = childCategories;

            }
            foreach (var x in request.Properties) {
                categoryToAdd.PropertyCategories.Add(new PropertyCategory
                {
                    PropertyId = x
                });
            }



            _context.Categories.Add(categoryToAdd);

            _context.SaveChanges();
        }
    }
}
