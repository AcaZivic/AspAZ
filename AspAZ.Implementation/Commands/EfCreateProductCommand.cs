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
    public class EfCreateProductCommand : ICreateProductCommand
    {

        private readonly GameKingdomContext _context;
        private readonly ProductValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateProductCommand(GameKingdomContext context, ProductValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 10;

        public string Name => "Create New Category using EF";

        public void Execute(CreateProductDTO request)
        {
            _validator.ValidateAndThrow(request); //ValidationException

            Product productToAdd = _mapper.Map<Product>(request);


            foreach (var it in request.Properties)
                productToAdd.ProductProperties.Add(new ProductProperty
                {
                    PropertyId = it.PropertyId,
                    Value = it.Value
                });



            _context.Products.Add(productToAdd);

            _context.SaveChanges();
        }
    }
}
