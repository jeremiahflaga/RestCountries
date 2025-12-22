namespace RestCountries.Core.Entities;

public class CountryLanguage
{
    public int CountryId { get; set; }
    public Country Country { get; protected set; }

    public int LanguageId { get; set; }
    public Language Language { get; protected set; }
}
