using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AfrowaveCountriesTools.Shared.Models.Jsons;

/// <summary>
/// Country name structure with common, official and native variants.
/// </summary>
public sealed class CountryName
{
	/// <summary>
	/// Common country name used in everyday contexts.
	/// </summary>
	[JsonPropertyName("common")]
	public string? Common { get; set; }

	/// <summary>
	/// Official country name as per authority.
	/// </summary>
	[JsonPropertyName("official")]
	public string? Official { get; set; }

	// v různých feedech bývá "native", "nativeName", apod.; sloučíme do tohoto
	/// <summary>
	/// Native names mapped by language code to localized name.
	/// </summary>
	[JsonPropertyName("native")]
	public Dictionary<string, LocalizedName>? Native { get; set; }
}