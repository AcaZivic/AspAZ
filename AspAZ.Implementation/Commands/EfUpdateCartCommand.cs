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
    public class EfUpdateCartCommand : IUpdateCartCommand
    {

        private readonly GameKingdomContext _context;
        private readonly UpdateCartValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateCartCommand(GameKingdomContext context, UpdateCartValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 38;

        public string Name => "Create New Cart using EF";

        public void Execute(UpdateCartDto request)
        {
            Cart cartToAdd = _context.Carts.Include(y=>y.ProductCarts).Where(x=>x.Id==request.Id).FirstOrDefault();
            
            var oldCart = _context.Carts.Where(x => x.Id == request.Id).First();

            if (cartToAdd == null)
            {
                throw new EntityNotFoundException(typeof(Cart).ToString(), request.Id);
            }

            _validator.ValidateAndThrow(request); //ValidationException

            

            //cartToAdd.ProductCarts = request.ProductCarts.Select(x => new ProductCart
            //{
            //    ProductId = x.ProductId,
            //    Quantity = x.Quantity,
            //}).ToList();


            //_mapper.Map(request, cartToAdd);// Zbog ovoga odlazi u added
            //_context.Entry(cartToAdd).State= EntityState.Modified;

           

            


            var shop = _context.RetailShops.Find(request.RetailShopId);
            var shopStorage = _context.ShopStorages.Where(x=>x.RetailShopId==shop.Id);

            foreach (var it in request.ProductCarts)
            {
                int quantiyTemp=0;
                if (oldCart.RetailShop.Id == request.RetailShopId)
                {
                    var existInBothCarts = oldCart.ProductCarts
                        .Any(x => it.ProductId == x.ProductId);
                    if (existInBothCarts)
                    {
                        var quantityOld = oldCart.ProductCarts.First(y => y.ProductId == it.ProductId).Quantity;
                        quantiyTemp= quantityOld;
                    }
                }

                var itemInShop = shopStorage
                    .Where(x => it.ProductId == x.ProductId)
                    .Select(x => x.Quantity).FirstOrDefault()+ quantiyTemp;

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

                if(quantiyTemp==0)
                    shopStorage.Where(x => x.ProductId == it.ProductId).First().Quantity -= it.Quantity;
                else
                {
                    shopStorage.Where(x => x.ProductId == it.ProductId).First().Quantity += quantiyTemp - it.Quantity;
                    
                }

                
            }

            cartToAdd.CustomerId = request.CustomerId;
            cartToAdd.EmployeeId = request.EmployeeId;
            cartToAdd.RetailShopId = request.RetailShopId;

            foreach (var item in cartToAdd.ProductCarts)
            {
                if (request.ProductCarts.Any(x => x.ProductId == item.ProductId))
                {
                    item.Quantity = request.ProductCarts.Where(x => x.ProductId == item.ProductId).Select(y => y.Quantity).First();
                }
            }


            _context.SaveChanges();
        }
    }
}
