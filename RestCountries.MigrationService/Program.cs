using Microsoft.EntityFrameworkCore;
using RestCountries.Data;
using RestCountries.MigrationService;

var builder = Host.CreateApplicationBuilder(args);

// Register DbContext
builder.Services.AddDbContext<CountriesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
