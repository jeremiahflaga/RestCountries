using Microsoft.EntityFrameworkCore;
using RestCountries.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestCountries.Data;

public class CountriesDbContext : DbContext
{
    public CountriesDbContext(DbContextOptions<CountriesDbContext> options) 
        : base(options) 
    {
    }

    public DbSet<Country> Countries => Set<Country>();
    public DbSet<Language> Languages => Set<Language>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Country>()
            .Property(x => x.CCA2)
            .HasMaxLength(2);

        modelBuilder.Entity<Language>()
            .Property(x => x.Code)
            .HasMaxLength(3);

        modelBuilder.Entity<CountryLanguage>(x =>
        {
            x.ToTable("CountryLanguages");

            // Composite PK and name
            x.HasKey(sc => new { sc.CountryId, sc.LanguageId });
        });
    }
}
