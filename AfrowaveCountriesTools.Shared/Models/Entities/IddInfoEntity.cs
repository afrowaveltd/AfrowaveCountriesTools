namespace AfrowaveCountriesTools.Shared.Models.Entities;

/// <summary>
/// Represents international direct dialing (IDD) information for a country.
/// </summary>
public class IddInfoEntity
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
	/// Root dialing prefix (e.g., "+").
	/// </summary>
	public string? Root { get; set; }
}
