namespace AfrowaveCountriesTools.Shared.Models.Entities;

/// <summary>
/// Represents an alternative spelling for a country.
/// </summary>
public class CountryAltSpelling
{
	/// <summary>
	/// Primary key.
	/// </summary>
	public int Id { get; set; }
	/// <summary>
	/// Foreign key to Country.
	/// </summary>
	public int CountryId { get; set; }
	/// <summary>
	/// Navigation property to Country.
	/// </summary>
	public Country Country { get; set; } = null!;
	/// <summary>
	/// Alternative spelling value.
	/// </summary>
	public string Value { get; set; } = string.Empty;
}
