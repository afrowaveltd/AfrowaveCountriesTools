namespace AfrowaveCountriesTools.Shared.Models.Entities;

/// <summary>
/// Represents the country name details including common and official names.
/// </summary>
public class CountryNameEntity
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
	/// Common country name.
	/// </summary>
	public string? Common { get; set; }
	/// <summary>
	/// Official country name.
	/// </summary>
	public string? Official { get; set; }
}
