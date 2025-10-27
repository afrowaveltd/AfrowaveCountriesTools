namespace AfrowaveCountriesTools.Shared.Models.Entities;

/// <summary>
/// Represents a language spoken in a country.
/// </summary>
public class CountryLanguage
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
	/// Language code (e.g., "cs").
	/// </summary>
	public string Code { get; set; } = string.Empty;
	/// <summary>
	/// Language name (e.g., "Czech").
	/// </summary>
	public string Name { get; set; } = string.Empty;
}
