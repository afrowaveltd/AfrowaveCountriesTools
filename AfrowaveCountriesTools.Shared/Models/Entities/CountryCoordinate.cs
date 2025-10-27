namespace AfrowaveCountriesTools.Shared.Models.Entities;

/// <summary>
/// Represents a latitude/longitude coordinate for a country.
/// </summary>
public class CountryCoordinate
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
	/// Latitude value.
	/// </summary>
	public double Latitude { get; set; }
	/// <summary>
	/// Longitude value.
	/// </summary>
	public double Longitude { get; set; }
}
