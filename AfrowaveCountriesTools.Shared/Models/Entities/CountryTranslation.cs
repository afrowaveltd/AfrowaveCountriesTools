namespace AfrowaveCountriesTools.Shared.Models.Entities;

/// <summary>
/// Represents a translation of the country name for a specific language.
/// </summary>
public class CountryTranslation
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
	/// Language code for the translation.
	/// </summary>
	public string LangCode { get; set; } = string.Empty;
	/// <summary>
	/// Official country name in the target language.
	/// </summary>
	public string? Official { get; set; }
	/// <summary>
	/// Common country name in the target language.
	/// </summary>
	public string? Common { get; set; }
}
