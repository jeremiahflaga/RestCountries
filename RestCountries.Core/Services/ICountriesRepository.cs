using RestCountries.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestCountries.Core.Services;

public interface ICountriesRepository
{
    IEnumerable<Country> GetAll(CountryQuery query);
}

public class CountryQuery
{
    public string? Region { get; set; }
    public string? Name { get; set; }
    public long? MinPopulation { get; set; }
    public string? Sort { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
}