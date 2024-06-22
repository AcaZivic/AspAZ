using AspAZ.Application.Exceptions;
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
    public class EfUpdateProductCommand : IUpdateProductCommand
    {

        private readonly GameKingdomContext _context;
        private readonly ProductUpdateValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateProductCommand(GameKingdomContext context, ProductUpdateValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 10;

        public string Name => "Update Product using EF";

        public void Execute(UpdateProductDTO request)
        {


            Product productToUpd = _context.Products.Find(request.Id);
            if (productToUpd == null)
            {
                throw new EntityNotFoundException(typeof(UpdateProductDTO).ToString(), request.Id);
            }

            _validator.ValidateAndThrow(request); //ValidationException


            
                _mapper.Map(request, productToUpd);


            //foreach (var it in request.Properties)
            //    productToUpd.ProductProperties.Add(new ProductProperty
            //    {
            //        PropertyId = it.PropertyId,
            //        Value = it.Value
            //    });



            _context.SaveChanges();
        }
    }
}
