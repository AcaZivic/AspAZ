using AspAZ.Application.Exceptions;
using AspAZ.Application.UseCases.Commands;
using AspAZ.DataAccess;
using AspAZ.DataTransfer;
using AspAZ.Domain;
using AspAZ.Implementation.Validators;
using AspYt.Application.DTO;
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
    public class EfCreateCartCommand : ICreateCartCommand
    {

        private readonly GameKingdomContext _context;
        private readonly CartValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateCartCommand(GameKingdomContext context, CartValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 38;

        public string Name => "Create New Cart using EF";

        public void Execute(CreateCartDto request)
        {
            _validator.ValidateAndThrow(request); //ValidationException


            Cart cartToAdd = _mapper.Map<Cart>(request);

            var shop = _context.RetailShops.Find(cartToAdd.RetailShopId);
            var shopStorage = _context.ShopStorages.Where(x=>x.RetailShopId==shop.Id);

            foreach (var it in cartToAdd.ProductCarts)
            {
                var itemInShop = _context.ShopStorages
                    .Where(x => it.ProductId == x.ProductId && x.RetailShopId == cartToAdd.RetailShopId)
                    .Select(x => x.Quantity).FirstOrDefault();

                if (itemInShop != null && itemInShop>0)
                {
                    if (it.Quantity > itemInShop)
                    {
                        throw new ConflictException("There is not enough products in storage !!!");
                    }
                }
                else
                {
                    throw new EntityNotFoundException($"There is no product in the shop storage {shop.Name} !!!", it.ProductId);
                }
                shopStorage.Where(x => x.ProductId == it.ProductId).First().Quantity -= it.Quantity;
                
            }



            _context.Carts.Add(cartToAdd);

            _context.SaveChanges();
        }
    }
}
