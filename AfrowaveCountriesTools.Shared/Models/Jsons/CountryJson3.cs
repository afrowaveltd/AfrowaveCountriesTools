using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AfrowaveCountriesTools.Shared.Models.Jsons;

/// <summary>
/// Detailed country model aggregating multiple sources (codes, status, geography, languages, currencies, etc.).
/// </summary>
public sealed class CountryJson3
{
	/// <summary>
	/// Country name including common/official/native variants.
	/// </summary>
	[JsonPropertyName("name")]
	public CountryName? Name { get; set; }

	/// <summary>
	/// Top-level domains.
	/// </summary>
	[JsonPropertyName("tld")]
	public List<string>? Tld { get; set; }

	/// <summary>
	/// ISO-3166 alpha-2 code.
	/// </summary>
	[JsonPropertyName("cca2")]
	public string? Cca2 { get; set; }

	/// <summary>
	/// ISO-3166 numeric code.
	/// </summary>
	[JsonPropertyName("ccn3")]
	public string? Ccn3 { get; set; }

	/// <summary>
	/// ISO-3166 alpha-3 code.
	/// </summary>
	[JsonPropertyName("cca3")]
	public string? Cca3 { get; set; }

	/// <summary>
	/// International Olympic Committee code.
	/// </summary>
	[JsonPropertyName("cioc")]
	public string? Cioc { get; set; }

	/// <summary>
	/// Whether the country is independent.
	/// </summary>
	[JsonPropertyName("independent")]
	public bool? Independent { get; set; }

	/// <summary>
	/// Status of the country/entity (e.g., officially-assigned).
	/// </summary>
	[JsonPropertyName("status")]
	public string? Status { get; set; }

	/// <summary>
	/// UN membership flag.
	/// </summary>
	[JsonPropertyName("unMember")]
	public bool? UnMember { get; set; }

	/// <summary>Currency map keyed by ISO currency code.</summary>
	[JsonPropertyName("currencies")] public Dictionary<string, CurrencyInfo>? Currencies { get; set; }

	/// <summary>International direct dialing info.</summary>
	[JsonPropertyName("idd")]
	public IddInfo? Idd { get; set; }

	/// <summary>Capital city/cities.</summary>
	[JsonPropertyName("capital")]
	public List<string>? Capital { get; set; }

	/// <summary>Alternative spellings.</summary>
	[JsonPropertyName("altSpellings")]
	public List<string>? AltSpellings { get; set; }

	/// <summary>Geographical region.</summary>
	[JsonPropertyName("region")]
	public string? Region { get; set; }

	/// <summary>Subregion.</summary>
	[JsonPropertyName("subregion")]
	public string? Subregion { get; set; }

	/// <summary>Language map keyed by language code.</summary>
	[JsonPropertyName("languages")]
	public Dictionary<string, string>? Languages { get; set; }

	/// <summary>Translations keyed by language code.</summary>
	[JsonPropertyName("translations")]
	public Dictionary<string, LocalizedName>? Translations { get; set; }

	/// <summary>Latitude/longitude coordinates.</summary>
	[JsonPropertyName("latlng")]
	public List<double>? LatLng { get; set; }

	/// <summary>Whether the country is landlocked.</summary>
	[JsonPropertyName("landlocked")]
	public bool? Landlocked { get; set; }

	/// <summary>Bordering country ISO-3 codes.</summary>
	[JsonPropertyName("borders")]
	public List<string>? Borders { get; set; }

	/// <summary>Total area in square kilometers.</summary>
	[JsonPropertyName("area")]
	public double? Area { get; set; }

	/// <summary>Emoji flag character.</summary>
	[JsonPropertyName("flag")]
	public string? Flag { get; set; }

	/// <summary>Demonyms by language code.</summary>
	[JsonPropertyName("demonyms")]
	public Dictionary<string, GenderedDemonym>? Demonyms { get; set; }

	/// <summary>Calling codes if present in source.</summary>
	[JsonPropertyName("callingCodes")]
	public List<string>? CallingCodes { get; set; }

	/// <summary>
	/// Captures any additional fields not explicitly mapped.
	/// </summary>
	[JsonExtensionData]
	public Dictionary<string, JsonElement>? Extra { get; set; }
}