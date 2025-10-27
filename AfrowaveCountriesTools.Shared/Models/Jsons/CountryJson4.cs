using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AfrowaveCountriesTools.Shared.Models.Jsons;

/// <summary>
/// Country model mapped to the countries4.json feed with identifiers, ISO codes,
/// currency information and a base64-encoded flag image.
/// </summary>
public sealed class CountryJson4
{
	/// <summary>
	/// Unique numeric identifier of the country entry.
	/// </summary>
	[JsonPropertyName("id")]
	public int Id { get; set; }

	/// <summary>
	/// Country display name.
	/// </summary>
	[JsonPropertyName("name")]
	public string Name { get; set; } = string.Empty;

	/// <summary>
	/// ISO-3166 alpha-2 country code (two-letter).
	/// </summary>
	[JsonPropertyName("isoAlpha2")]
	public string IsoAlpha2 { get; set; } = string.Empty;

	/// <summary>
	/// ISO-3166 alpha-3 country code (three-letter).
	/// </summary>
	[JsonPropertyName("isoAlpha3")]
	public string IsoAlpha3 { get; set; } = string.Empty;

	/// <summary>
	/// ISO-3166 numeric country code.
	/// </summary>
	[JsonPropertyName("isoNumeric")]
	public int IsoNumeric { get; set; } = 0;

	/// <summary>
	/// Currency metadata such as code, name and symbol.
	/// </summary>
	[JsonPropertyName("currency")]
	public CurrencyInfo Currency { get; set; }

	/// <summary>
	/// Base64-encoded flag image content.
	/// </summary>
	[JsonPropertyName("flag")]
	public string Base64Flag { get; set; } = string.Empty;
}