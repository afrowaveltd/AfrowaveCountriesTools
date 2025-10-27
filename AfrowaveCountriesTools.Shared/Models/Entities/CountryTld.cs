namespace AfrowaveCountriesTools.Shared.Models.Entities;

/// <summary>
/// Represents a top-level domain (TLD) for a country.
/// </summary>
public class CountryTld
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
	/// TLD value (e.g., ".cz").
	/// </summary>
	public string Value { get; set; } = string.Empty;
}
