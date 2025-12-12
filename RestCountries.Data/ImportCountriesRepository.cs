using EFCore.BulkExtensions;
using NetTopologySuite.Index.HPRtree;
using RestCountries.Core;
using RestCountries.WebApi.Controllers.Import;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestCountries.Data;

public class ImportCountriesRepository : IImportCountriesRepository
{
    private readonly CountriesDbContext dbContext;

    public ImportCountriesRepository(CountriesDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    private BulkConfig bulkConfig = new BulkConfig
    {
        SetOutputIdentity = true,      // get generated IDs for inserts
        PreserveInsertOrder = true,    // keep list order if needed
        UpdateByProperties = new List<string> { "CCA2" } // default is PK
    };

    public async Task BulkUpsertAsync(IEnumerable<Country> countries)
    {
        await dbContext.BulkInsertOrUpdateAsync(countries, bulkConfig);
    }
}
