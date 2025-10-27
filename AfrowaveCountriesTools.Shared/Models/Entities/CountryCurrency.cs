namespace AfrowaveCountriesTools.Shared.Models.Entities;

/// <summary>
/// Join entity for many-to-many relationship between Country and Currency.
/// </summary>
public class CountryCurrency
{
	/// <summary>
	/// Foreign key to Country.
	/// </summary>
	public int CountryId { get; set; }
	/// <summary>
	/// Navigation property to Country.
	/// </summary>
	public Country Country { get; set; } = null!;
	/// <summary>
	/// Foreign key to Currency.
	/// </summary>
	public int CurrencyId { get; set; }
	/// <summary>
	/// Navigation property to Currency.
	/// </summary>
	public Currency Currency { get; set; } = null!;
	/// <summary>
	/// Raw currency code as used in the source JSON (optional).
	/// </summary>
	public string? RawCode { get; set; }
}
