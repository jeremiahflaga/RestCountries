using Microsoft.EntityFrameworkCore;
using RestCountries.Core.Services;
using RestCountries.Data;
using RestCountries.Data.Repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CountriesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IImportCountriesRepository, ImportCountriesRepository>();
builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services
    .AddHttpClient("RestCountriesHttpClient", c =>
    {
        c.BaseAddress = new Uri("https://restcountries.com");
    })
    .AddStandardResilienceHandler(options =>
    {
        options.Retry.MaxRetryAttempts = 3;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/ping", () => "Hello, World!");

app.Run();

// Make the implicit Program class accessible to integration tests
public partial class Program { }