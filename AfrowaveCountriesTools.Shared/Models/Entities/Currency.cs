namespace AfrowaveCountriesTools.Shared.Models.Entities;

/// <summary>
/// Represents a currency with code, name, and symbol.
/// </summary>
public class Currency
{
	/// <summary>
	/// Primary key.
	/// </summary>
	public int Id { get; set; }
	/// <summary>
	/// ISO currency code.
	/// </summary>
	public string Code { get; set; } = string.Empty;
	/// <summary>
	/// Currency name.
	/// </summary>
	public string? Name { get; set; }
	/// <summary>
	/// Currency symbol.
	/// </summary>
	public string? Symbol { get; set; }
	/// <summary>
	/// Navigation property for countries using this currency.
	/// </summary>
	public ICollection<CountryCurrency> CountryCurrencies { get; set; } = new List<CountryCurrency>();
}
