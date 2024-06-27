
//using AspAZ.Implementation.Logging.UseCases;
using AspAZ.Implementation;
using AspAZ.Implementation.Validators;
using System.IdentityModel.Tokens.Jwt;
using AspAZ.Implementation.Commands;
using AspAZ.Api.Core;
using AspAZ.Application;
using AspAZ.DataAccess;
using AspAZ.Application.UseCases.Queries;
using AspAZ.Implementation.Queries;
using AspAZ.Application.UseCases.Commands;
using AutoMapper;
using AspAZ.Implementation.Profiles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;
using AspAZ.DataAccess.Migrations;
using AspAZ.Application.Email;
using AspAZ.Implementation.Email;

namespace AspAZ.API.Core
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
           //AddTransient<ICreateGroupCommand, EfCreateGroupCommand>();
           //AddTransient<IDeleteGroupCommand, EfDeleteGroupCommand>();
           services.AddTransient<UseCaseExecutor>();
            services.AddTransient<ICreateManufacturerCommand, EfCreateManufacturerCommand>();
            services.AddTransient<IGetManufacturerQuery, EfGetManufacturerQuery>();
            services.AddTransient<IDeleteManufacturerCommand, EfDeleteManufacturerCommand>();
            services.AddTransient<IUpdateManufacturerCommand, EfUpdateManufacturerCommand>();
            services.AddTransient<IDeleteGroupCommand, EfDeleteGroupCommand>();
            services.AddTransient<IDeletePropertyCommand, EfDeletePropertyCommand>();
            services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
            services.AddTransient<IUpdateCategoryCommand, EfUpdateCategoryCommand>();
            services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>();
            services.AddTransient<IGetCategoryQuery, EfGetCategoryQuery>();
            services.AddTransient<ICreatePriceListCommand, EfCreatePriceListCommand>();
            services.AddTransient<IUpdatePriceListCommand, EfUpdatePriceListCommand>();
            services.AddTransient<IGetPriceListQuery, EfGetPriceListQuery>();
            services.AddTransient<IDeletePriceListCommand, EfDeletePriceListCommand>();
            services.AddTransient<ICreateProductCommand, EfCreateProductCommand>();
            services.AddTransient<IUpdateProductCommand, EfUpdateProductCommand>();
            services.AddTransient<IDeleteProductCommand, EfDeleteProductCommand>();
            services.AddTransient<IGetProductQuery, EfGetProductsQuery>();
            services.AddTransient<ICreateRetailShopCommand,EfCreateRetailShopCommand>();
            services.AddTransient<IUpdateRetailShopCommand, EfUpdateRetailShopCommand>();
            services.AddTransient<IDeleteRetailShopCommand, EfDeleteRetailShopCommand>();
            services.AddTransient<IGetRetailShopQuery, EfGetRetailShopQuery>();
            services.AddTransient<ICreateCustomerCommand, EfCreateCustomerCommand>();
            services.AddTransient<IUpdateCustomerCommand, EfUpdateCustomerCommand>();
            services.AddTransient<IDeleteCustomerCommand, EfDeleteCustomerCommand>();
            services.AddTransient<IGetCustomerQuery, EfGetCustomerQuery>();
            services.AddTransient<ICreateEmployeeCommand, EfCreateEmployeeCommand>();
            services.AddTransient<IUpdateEmployeeCommand, EfUpdateEmployeeCommand>();
            services.AddTransient<IDeleteEmployeeCommand, EfDeleteEmployeeCommand>();
            services.AddTransient<IGetEmployeeQuery, EfGetEmployeeQuery>();
            services.AddTransient<ICreateCartCommand, EfCreateCartCommand>();
            services.AddTransient<IUpdateCartCommand, EfUpdateCartCommand>();
            services.AddTransient<IDeleteCartCommand, EfDeleteCartCommand>();
            services.AddTransient<IGetCartQuery, EfGetCartQuery>();
            services.AddTransient<JwtManager>();

            services.AddTransient<IEmailSender, SmtpEmailSender>();












            services.AddTransient<IUpdateGroupCommand, EfUpdateGroupCommand>();
            services.AddTransient<IUseCaseLogger, EfUseCaseLogger>();
            services.AddTransient<IGetUseCaseLogQuery, EfGetUseCaseLogQuery>();
            services.AddTransient<IGetGroupQuery, EfGetGroupsQuery>();
            services.AddTransient<IGetPropertyQuery, EfGetPropertyQuery>();
            services.AddTransient<IUpdatePropertyCommand, EfUpdatePropertyCommand>();


            services.AddTransient<ManufacturerValidator>();
            services.AddTransient<GroupUpdateValidator>();
            services.AddTransient<GroupValidator>();
            services.AddTransient<PropertyValidator>();
            services.AddTransient<PropertyUpdateValidator>();
            services.AddTransient<CategoryValidator>();
            services.AddTransient<UpdateCategoryValidator>();
            services.AddTransient<PriceListValidator>();
            services.AddTransient<UpdatePriceListValidator>();
            services.AddTransient<ProductValidator>();
            services.AddTransient<ProductUpdateValidator>();
            services.AddTransient<RetailShopValidator>();
            services.AddTransient<UpdateRetailShopValidator>();
            services.AddTransient<CustomerValidator>();
            services.AddTransient<EmployeeValidator>();

            services.AddTransient<EmployeeUpdateValidator>();
            services.AddTransient<CartProductValidator>();
            services.AddTransient<CartValidator>();
            services.AddTransient<UpdateCartValidator>();





            services.AddTransient<ICreatePropertyCommand, EfCreatePropertyCommand>();

            services.AddAutoMapper(services.GetType().Assembly);
            services.AddAutoMapper(typeof(EfGetGroupsQuery).Assembly);
            services.AddAutoMapper(typeof(EfCreatePropertyCommand).Assembly);
            services.AddAutoMapper(typeof(EfCreateProductCommand).Assembly);

            //services.AddAutoMapper(typeof(EfCreatePropertyCommand).Assembly);


            services.AddTransient<ICreateGroupCommand, EfCreateGroupCommand>();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new GroupProfile());
                mc.AddProfile(new PropertyProfile());
                mc.AddProfile(new CategoryProfile());
                mc.AddProfile(new PriceListProfile());
                mc.AddProfile(new ProductProfile());
                mc.AddProfile(new RetailShopProfile());
                mc.AddProfile(new CustomerProfile());
                mc.AddProfile(new EmployeeProfile());
                mc.AddProfile(new CartProfile());



            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);



        }


        //public static void AddApplicationActor(this IServiceCollection services)
        //{
        //    services.AddTransient<IApplicationActor>(x =>
        //    {
        //        var accessor = x.GetService<IHttpContextAccessor>();


        //         var user = accessor.HttpContext.User;

        //        if (user.FindFirst("ActorData") == null)
        //        {
        //            return new AnonymousActor();
        //        }

        //        var actorString = user.FindFirst("ActorData").Value;

        //        var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

        //        return actor;

        //    });
        //}
        //, AppSettings appSettings
        public static void AddJwt(this IServiceCollection services)
        {
            services.AddTransient<JwtManager>(x =>
            {
                var context = x.GetService<GameKingdomContext>();

                //appSettings.JwtIssuer, appSettings.JwtSecretKey
                return new JwtManager(context);
            });

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "asp_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asp123"+ "potrebnoRadiRadaTokena-velicina-mora-biti-veca-od-256-bita")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static Guid? GetTokenId(this HttpRequest request)
        {
            if (request == null || !request.Headers.ContainsKey("Authorization"))
            {
                return null;
            }

            string authHeader = request.Headers["Authorization"].ToString();

            if(authHeader.Split("Bearer ").Length != 2)
            {
                return null;
            }

            string token = authHeader.Split("Bearer ")[1];

            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(token);

            var claims = tokenObj.Claims;

            var claim = claims.First(x => x.Type == "jti").Value;

            var tokenGuid = Guid.Parse(claim);

            return tokenGuid;
        }
    }
}
