using BeerCollectionBusinessLogic.IService;
using BeerCollectionBusinessLogic.Service;
using BeerCollectionDataAccess;
using BeerCollectionDataAccess.Interfaces;
using BeerCollectionDataAccess.Mapping;
using BeerCollectionDataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBeerService, BeerService>();
builder.Services.AddScoped<IBeerRepository, BeerRepository>();

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<BeerCollectionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BeerCollectionContext>();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
