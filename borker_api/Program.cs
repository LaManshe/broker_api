using borker_api.ApiInteraction;
using borker_api.DAL.Entities;
using borker_api.Data;
using borker_api.Models.Mapping;
using borker_api.Services;
using borker_api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiServices();
builder.Services.AddTransient<IBestExchangeCompute, BestExchangeComputer>();
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddTransient<DataRates>();
builder.Services.AddTransient<IGetRates<Rate>, GetRatesFromDbAdditionalFromApi<Rate>>();

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

app.Run();
