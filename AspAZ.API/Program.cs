using AspAZ.Api.Core;
using AspAZ.API.Core;
using AspAZ.Application;
using AspAZ.DataAccess;
using AspAZ.Implementation.Commands;
using AspAZ.Implementation.Profiles;
using AspAZ.Implementation.Validators;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using AspAZ.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "GameKingdom API",
        Description = "An ASP.NET Core Web API for cash register GameKinhdom",
        TermsOfService = new Uri("https://github.com/AcaZivic/AspAZ/blob/master/PROJEKTNI%20ZADATAK%20-%20GAME%20KINGDOM.pdf"),
        //Contact = new OpenApiContact
        //{
        //    Name = "",
        //    Url = new Uri("")
        //}
        //License = new OpenApiLicense
        //{
        //    Name = "Example License",
        //    Url = new Uri("https://example.com/license")
        //}
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddTransient<GameKingdomContext>();
builder.Services.AddHttpContextAccessor();

//builder.Services.AddTransient<IApplicationActor, AdminFakeApiActor>();

builder.Services.AddTransient<IApplicationActorProvider>(x =>
{
    //    //var accessor = x.GetService<IHttpContextAccessor>();
    //    //var user = accessor.HttpContext.User;


    //    //if(user.FindFirst("ActorData")==null)
    //    //{
    //    //    throw new Exception("Greska");
    //    //}

    //    //var actorString = user.FindFirst("ActorData").Value;
    //    //var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

    //    //return actor;

    var accessor = x.GetService<IHttpContextAccessor>();

    var request = accessor.HttpContext.Request;

    var authHeader = request.Headers.Authorization.ToString();

    var context = x.GetService<GameKingdomContext>();

    return new JWTprovider(authHeader);
});

builder.Services.AddTransient<IApplicationActor>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();
    if (accessor.HttpContext == null)
    {
        return new UnauthorizedActor();
    }

    return x.GetService<IApplicationActorProvider>().GetActor();
});

builder.Services.AddAutoMapper(builder.GetType().Assembly);
builder.Services.AddUseCases();
builder.Services.AddTransient<IExceptionLogger, DbExceptionLogger>();
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddApplicationActor();



//appSettings
builder.Services.AddJwt();


var app = builder.Build();
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
