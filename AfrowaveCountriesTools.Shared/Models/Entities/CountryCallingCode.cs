namespace AfrowaveCountriesTools.Shared.Models.Entities;

/// <summary>
/// Represents a calling code for a country.
/// </summary>
public class CountryCallingCode
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
	/// Calling code value (e.g., "+420").
	/// </summary>
	public string Value { get; set; } = string.Empty;
}
