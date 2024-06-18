using AspAZ.DataAccess;
using AspAZ.Domain;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspAZ.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        private GameKingdomContext _gameContext;

        public TestController()
        {
            _gameContext = new GameKingdomContext();
        }

        // GET: api/<TestController>
        [HttpGet]
        public IActionResult Get()
        {
            //---------MANUFACTURER
            //List<Manufacturer> manufacturers = ManufacturerFaker();
            //_gameContext.Manufacturers.AddRange(manufacturers);

            //---------RETAIL SHOP



            //---------Properties
            //List<Property> property = PropertyFaker(_gameContext);
            //_gameContext.Properties.AddRange(property);

            //---------Categories
            //CategoryFaker();

            //---------Product Price
            //ProductPrice();






            //_gameContext.SaveChanges();


            return Ok();
        }

        private void ProductPrice()
        {



            //var productProperty = productPropertyFaker.Generate(20);


            var manufacturer = _gameContext.Manufacturers.AsQueryable();
            var category = _gameContext.Categories.AsQueryable();


            var priceListFaker = new Faker<PriceList>();


            var listaManu = manufacturer.Select(x => x.Id).ToList();
            var listaCate = category.Select(x => x.Id).ToList();


            var productFaker = new Faker<Product>();

            productFaker.RuleFor(x => x.Name, n => n.Commerce.ProductName());
            productFaker.RuleFor(x => x.BarCode, n => n.Commerce.Ean13());
            productFaker.RuleFor(x => x.Description, n => "Opis proizvoda");
            productFaker.RuleFor(x => x.ProductCode, n => String.Join("", n.Random.Digits(6)));
            productFaker.RuleFor(x => x.ManufacturerId, n => n.PickRandom(listaManu));
            productFaker.RuleFor(x => x.CategoryId, n => n.PickRandom(listaCate));
            productFaker.RuleFor(x => x.PriceList, n => n.PickRandom(priceListFaker));
            //productFaker.RuleFor(x => x.ProductProperties, n => productPropertyFaker.Generate(3));



            var product = productFaker.Generate(20);

            var shopStorageFaker = new Faker<ShopStorage>();

            shopStorageFaker.RuleFor(x => x.Quantity, n => n.Random.Int(20, 100));
            shopStorageFaker.RuleFor(x => x.lastTimeSupply, n => n.Date.Between(DateTime.Now.AddDays(-200), DateTime.Now));
            shopStorageFaker.RuleFor(x => x.Product, n => n.PickRandom(product));




            var retailShopFaker = new Faker<RetailShop>();




            retailShopFaker.RuleFor(x => x.Address, n => n.Address.StreetName());
            retailShopFaker.RuleFor(x => x.AddressNum, n => n.Address.BuildingNumber());
            retailShopFaker.RuleFor(x => x.City, n => n.Address.City());
            retailShopFaker.RuleFor(x => x.Telephone, n => n.Phone.PhoneNumberFormat(4));
            retailShopFaker.RuleFor(x => x.Name, n => n.Lorem.Word() + " " + n.Address.State());
            //retailShopFaker.RuleFor(x => x.ShopStorages, n => shopStorageFaker.Generate(10));




            var retailShop = retailShopFaker.Generate(10);


            priceListFaker.RuleFor(x => x.Price, n => Convert.ToDouble(n.Commerce.Price()));
            priceListFaker.RuleFor(x => x.DateFrom, n => n.Date.Between(DateTime.Now.AddDays(-300), DateTime.Now));
            //priceListFaker.RuleFor(x => x.Product, n => n.PickRandom(product));


            var priceList = priceListFaker.Generate(20);


            //int i = 0;
            //foreach (var pr in product)
            //{
            //    priceList[i].Product = pr;
            //    pr.PriceList = priceList[i++];

            //}

            _gameContext.Products.AddRange(product);
            _gameContext.PriceLists.AddRange(priceList);
            _gameContext.RetailShops.AddRange(retailShop);
        }

        private void CategoryFaker()
        {
            var categoryFaker = new Faker<Category>();

            categoryFaker.RuleFor(x => x.Name, n => n.Commerce.Categories(1).First());
            categoryFaker.RuleFor(x => x.Description, n => String.Join(" ", n.Lorem.Words()));

            var category = categoryFaker.Generate(20);

            var categoryFaker2 = new Faker<Category>();

            categoryFaker2.RuleFor(x => x.Name, n => n.Commerce.Categories(1).First());
            categoryFaker2.RuleFor(x => x.Description, n => String.Join(" ", n.Lorem.Words()));
            categoryFaker2.RuleFor(x => x.Parent, n => n.PickRandom(category));


            var category2 = categoryFaker2.Generate(10);

            _gameContext.Categories.AddRange(category);
            _gameContext.Categories.AddRange(category2);
        }

        private static List<Property> PropertyFaker(GameKingdomContext gk)
        {
            var productPropertyFaker = new Faker<ProductProperty>();
            var propArr = gk.Products.AsQueryable();

            productPropertyFaker.RuleFor(x => x.Value, n => n.Commerce.ProductAdjective());
            productPropertyFaker.RuleFor(x => x.Product, n => n.PickRandom(propArr.ToList()));

            var propertyFaker = new Faker<Property>();


            propertyFaker.RuleFor(x => x.Name, n => n.Random.Word());
            propertyFaker.RuleFor(x => x.MeasureUnit, n => n.Lorem.Word());
            propertyFaker.RuleFor(x => x.ProductProperties, n => productPropertyFaker.Generate(10));




            var property = propertyFaker.Generate(20);
            return property;
        }

        private static List<RetailShop> RetailShopFaker()
        {
            var shopStorageFaker = new Faker<ShopStorage>();
            //var product = _gameconte

            shopStorageFaker.RuleFor(x => x.Quantity, n => n.Random.Int(20, 100));
            shopStorageFaker.RuleFor(x => x.lastTimeSupply, n => n.Date.Between(DateTime.Now.AddDays(-200), DateTime.Now));
            //shopStorageFaker.RuleFor(x => x.Product, n => n.PickRandom(product.ToList()));




            var retailShopFaker = new Faker<RetailShop>();




            retailShopFaker.RuleFor(x => x.Address, n => n.Address.StreetName());
            retailShopFaker.RuleFor(x => x.AddressNum, n => n.Address.BuildingNumber());
            retailShopFaker.RuleFor(x => x.City, n => n.Address.City());
            retailShopFaker.RuleFor(x => x.Telephone, n => n.Phone.PhoneNumberFormat(4));
            retailShopFaker.RuleFor(x => x.Name, n => n.Lorem.Word() + " " + n.Address.State());
            retailShopFaker.RuleFor(x => x.ShopStorages, n => shopStorageFaker.Generate(10));




            var retailShop = retailShopFaker.Generate(10);
            return retailShop;
        }

        private static List<Manufacturer> ManufacturerFaker()
        {
            var manufacturerFaker = new Faker<Manufacturer>();

            manufacturerFaker.RuleFor(x => x.Name,
                n => n.Name.JobDescriptor() + ' ' + n.Lorem.Word());

            manufacturerFaker.RuleFor(x => x.Description,
                n => String.Join(" ", n.Lorem.Words()));

            var manufacturers = manufacturerFaker.Generate(50);
            return manufacturers;
        }

        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
