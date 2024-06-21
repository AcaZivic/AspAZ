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
    public class EfUpdateCategoryCommand : IUpdateCategoryCommand
    {

        private readonly GameKingdomContext _context;
        private readonly UpdateCategoryValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateCategoryCommand(GameKingdomContext context, UpdateCategoryValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 11;

        public string Name => "Update  Category using EF";

        public void Execute(UpdateCategoryDto request)
        {
            _validator.ValidateAndThrow(request);

            Category categoryToUpdate = _context.Categories.Find(request.Id);
            

            if (request.ChildIds != null)
            {

                var childCategories = _context.Categories
                                              .Where(c => request.ChildIds.Contains(c.Id))
                                              .ToList();
                categoryToUpdate.Children = childCategories;

            }

            foreach (var x in request.Properties)
            {
                categoryToUpdate.PropertyCategories.Add(new PropertyCategory
                {
                    PropertyId = x
                });
            }

            _mapper.Map(request, categoryToUpdate );


            _context.SaveChanges();
        }
    }
}
