using AspAZ.Api.Core;
using AspAZ.API.Core;
using AspAZ.Application;
using AspAZ.DataAccess;
using AspAZ.Implementation.Commands;
using AspAZ.Implementation.Profiles;
using AspAZ.Implementation.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddTransient<GameKingdomContext>();


//builder.Services.AddAutoMapper(builder.GetType().Assembly);



builder.Services.AddUseCases();

builder.Services.AddTransient<IExceptionLogger, DbExceptionLogger>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddTransient<IApplicationActor>(x =>
//{
//    var accessor = x.GetService<IHttpContextAccessor>();
//    if (accessor.HttpContext == null)
//    {
//        return new UnauthorizedActor();
//    }

//    return x.GetService<IApplicationActorProvider>().GetActor();
//});


var app = builder.Build();
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
