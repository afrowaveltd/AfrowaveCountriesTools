namespace AfrowaveCountriesTools.Shared.Models.Entities;

/// <summary>
/// Represents a gendered demonym for a country in a specific language.
/// </summary>
public class CountryDemonym
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
	/// Language code for the demonym.
	/// </summary>
	public string LangCode { get; set; } = string.Empty;
	/// <summary>
	/// Male demonym.
	/// </summary>
	public string? Male { get; set; }
	/// <summary>
	/// Female demonym.
	/// </summary>
	public string? Female { get; set; }
}
