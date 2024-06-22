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
    public class EfCreateRetailShopCommand : ICreateRetailShopCommand
    {

        private readonly GameKingdomContext _context;
        private readonly RetailShopValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateRetailShopCommand(GameKingdomContext context, RetailShopValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 20;

        public string Name => "Create New Retail shop using EF";

        public void Execute(CreateRetailShopDTO request)
        {
            _validator.ValidateAndThrow(request); //ValidationException




            RetailShop? temp = _mapper.Map<RetailShop>(request);



            var shopPro = request.ShopProducts.Select(x => new ShopStorage
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                lastTimeSupply = x.LastTimeSupply

            }).First();

            temp.ShopStorages.Add(shopPro);

            //temp.ShopStorages.Add(new ShopStorage
            //{

            //    ProductId = 3,
            //    Quantity = 3,
            //    lastTimeSupply = DateTime.Now
            //});

            _context.RetailShops.Add(temp);

            _context.SaveChanges();
        }
    }
}
