
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

namespace AspAZ.API.Core
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
           //AddTransient<ICreateGroupCommand, EfCreateGroupCommand>();
           //AddTransient<IDeleteGroupCommand, EfDeleteGroupCommand>();
           services.AddTransient<UseCaseExecutor>();
           services.AddTransient<IApplicationActor, AdminFakeApiActor>();
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



            services.AddTransient<ICreatePropertyCommand, EfCreatePropertyCommand>();

            services.AddAutoMapper(services.GetType().Assembly);
            services.AddAutoMapper(typeof(EfGetGroupsQuery).Assembly);
            services.AddAutoMapper(typeof(EfCreatePropertyCommand).Assembly);
            //services.AddAutoMapper(typeof(EfCreatePropertyCommand).Assembly);


            services.AddTransient<ICreateGroupCommand, EfCreateGroupCommand>();
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new GroupProfile());
                mc.AddProfile(new PropertyProfile());
                mc.AddProfile(new CategoryProfile());
                mc.AddProfile(new PriceListProfile());

            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);



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
