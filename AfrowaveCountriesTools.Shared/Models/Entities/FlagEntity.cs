namespace AfrowaveCountriesTools.Shared.Models.Entities;

/// <summary>
/// Represents flag asset references for a country (PNG, SVG, alt text, base64).
/// </summary>
public class FlagEntity
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
	/// PNG image URL.
	/// </summary>
	public string? Png { get; set; }
	/// <summary>
	/// SVG image URL.
	/// </summary>
	public string? Svg { get; set; }
	/// <summary>
	/// Alternative text for the flag.
	/// </summary>
	public string? Alt { get; set; }
	/// <summary>
	/// Base64-encoded flag image.
	/// </summary>
	public string? Base64 { get; set; }
}
