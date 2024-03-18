using EgeriaTaskBackend.Business;
using EgeriaTaskBackend.Domain.Dto;
using EgeriaTaskBackend.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EgeriaContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("EgeriaDbFirst")));

//AutoMapper
builder.Services.AddAutoMapper(typeof(CustomerDto));
builder.Services.AddAutoMapper(typeof(OrderDto));
// CORS politikalarýný yapýlandýrma
builder.Services.AddCors();



#region Scrutor resolvers

var typeBaseService = typeof(BaseService);

var assembly = typeBaseService.Assembly;

builder.Services.Scan(selector =>
        selector
            .FromAssemblies(assembly)
            .AddClasses(classSelector => classSelector.AssignableTo(typeof(BaseService)))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(builder =>
{
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
    builder.AllowAnyOrigin();
    builder.WithHeaders("Content-Type");
  
});




app.Run();
