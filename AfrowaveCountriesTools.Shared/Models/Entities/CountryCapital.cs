namespace AfrowaveCountriesTools.Shared.Models.Entities;

/// <summary>
/// Represents a capital city for a country.
/// </summary>
public class CountryCapital
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
	/// Capital city name.
	/// </summary>
	public string Value { get; set; } = string.Empty;
}
