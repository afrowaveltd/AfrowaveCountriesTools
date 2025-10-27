using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AfrowaveCountriesTools.Shared.Models.Jsons;

/// <summary>
/// Currency information with ISO currency name and symbol.
/// </summary>
public sealed class CurrencyInfo
{
	/// <summary>
	/// Gets or sets the code associated with the object.
	/// </summary>
	[JsonPropertyName("code")]
	public string? Code { get; set; }

	/// <summary>
	/// Currency display name, e.g., "Euro".
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Currency symbol, e.g., "€".
	/// </summary>
	[JsonPropertyName("symbol")]
	public string? Symbol { get; set; }
}