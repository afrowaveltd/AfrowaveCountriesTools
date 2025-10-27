namespace AfrowaveCountriesTools.Shared.Models.Entities;

/// <summary>
/// Represents a dialing suffix for international direct dialing (IDD) info.
/// </summary>
public class IddSuffix
{
	/// <summary>
	/// Primary key.
	/// </summary>
	public int Id { get; set; }
	/// <summary>
	/// Foreign key to IddInfoEntity.
	/// </summary>
	public int IddInfoId { get; set; }
	/// <summary>
	/// Navigation property to IddInfoEntity.
	/// </summary>
	public IddInfoEntity IddInfo { get; set; } = null!;
	/// <summary>
	/// Suffix value (e.g., "420").
	/// </summary>
	public string Value { get; set; } = string.Empty;
}
