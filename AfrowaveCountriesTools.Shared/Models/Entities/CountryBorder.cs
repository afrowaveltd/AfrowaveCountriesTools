namespace AfrowaveCountriesTools.Shared.Models.Entities;

/// <summary>
/// Represents a bordering country (by ISO-3 code).
/// </summary>
public class CountryBorder
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
	/// ISO-3 code of the neighboring country.
	/// </summary>
	public string Value { get; set; } = string.Empty;
}
