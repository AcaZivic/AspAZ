using AspAZ.Application.Exceptions;
using AspAZ.Application.UseCases.Commands;
using AspAZ.DataAccess;
using AspAZ.DataTransfer;
using AspAZ.Domain;
using AspAZ.Implementation.Profiles;
using AspAZ.Implementation.Validators;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AspAZ.Implementation.Commands
{
    public class EfUpdateRetailShopCommand : IUpdateRetailShopCommand
    {
        private readonly GameKingdomContext _context;
        private readonly UpdateRetailShopValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateRetailShopCommand(GameKingdomContext context, UpdateRetailShopValidator guv, IMapper mapper)
        {
            _context = context;
            _validator = guv;
            _mapper = mapper;
        }

        public int Id => 15;

        public string Name => "Updating retail shop";

        public void Execute(UpdateRetailShopDTO data)
        {
            var rshop = _context.RetailShops.Find(data.Id);

            if (rshop == null)
            {
                throw new EntityNotFoundException(typeof(RetailShop).ToString(), data.Id);
            }
            _validator.ValidateAndThrow(data); //ValidationException


            _mapper.Map(data, rshop);

            

            var shopPro = data.ShopProducts.Select(x => new ShopStorage
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                lastTimeSupply = x.LastTimeSupply

            }).First();

            rshop.ShopStorages.Add(shopPro);


            _context.SaveChanges();
        }
    }
}
