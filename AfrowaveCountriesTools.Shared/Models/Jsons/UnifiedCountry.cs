using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AfrowaveCountriesTools.Shared.Models.Jsons;

/// <summary>
/// Unified country model combining multiple feeds (names, codes, flags, geodata, languages, currencies, demonyms, calling info).
/// </summary>
public sealed class UnifiedCountry
{
	// --- KÓDY & NÁZEV ---
	/// <summary>Country name with common/official/native variants.</summary>
	[JsonPropertyName("name")]
	public CountryName? Name { get; set; }

	/// <summary>Top-level domains.</summary>
	[JsonPropertyName("tld")]
	public List<string>? Tld { get; set; }

	/// <summary>ISO-3166 alpha-2 code.</summary>
	[JsonPropertyName("cca2")]
	public string? Cca2 { get; set; }   // ISO-2

	/// <summary>ISO-3166 numeric code.</summary>
	[JsonPropertyName("ccn3")]
	public string? Ccn3 { get; set; }   // numeric (string ve zdroji)

	/// <summary>ISO-3166 alpha-3 code.</summary>
	[JsonPropertyName("cca3")]
	public string? Cca3 { get; set; }   // ISO-3

	/// <summary>International Olympic Committee code.</summary>
	[JsonPropertyName("cioc")]
	public string? Cioc { get; set; }

	// --- STATUS / ČLENSTVÍ ---
	/// <summary>Whether the country is independent.</summary>
	[JsonPropertyName("independent")]
	public bool? Independent { get; set; }

	/// <summary>Status of the country/entity.</summary>
	[JsonPropertyName("status")]
	public string? Status { get; set; }

	/// <summary>UN membership flag.</summary>
	[JsonPropertyName("unMember")]
	public bool? UnMember { get; set; }

	// --- TELEFON / VLÁJKY (doplněno z countries.json / countries2.json) ---
	/// <summary>International dialing code, e.g., "+420" (from countries.json).</summary>
	[JsonPropertyName("dialCode")]
	public string? DialCode { get; set; }   // např. "+420" (z countries.json)

	/// <summary>Flag asset references (PNG/SVG/alt from countries2.json).</summary>
	[JsonPropertyName("flags")]
	public Flag? Flags { get; set; }   // png/svg/alt (z countries2.json)

	// --- GEOGRAFIE ---
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

	/// <summary>Latitude/longitude coordinates.</summary>
	[JsonPropertyName("latlng")]
	public List<double>? LatLng { get; set; }

	/// <summary>Whether the country is landlocked.</summary>
	[JsonPropertyName("landlocked")]
	public bool? Landlocked { get; set; }

	/// <summary>Bordering country ISO-3 codes.</summary>
	[JsonPropertyName("borders")]
	public List<string>? Borders { get; set; } // typicky ISO-3 kódy

	/// <summary>Total area in square kilometers.</summary>
	[JsonPropertyName("area")]
	public double? Area { get; set; }

	// --- JAZYKY / PŘEKLADY / MĚNY / DEMONYMS ---
	/// <summary>Languages keyed by language code.</summary>
	[JsonPropertyName("languages")]
	public Dictionary<string, string>? Languages { get; set; }

	/// <summary>Translations keyed by language code.</summary>
	[JsonPropertyName("translations")]
	public Dictionary<string, LocalizedName>? Translations { get; set; }

	/// <summary>Currency map keyed by ISO currency code.</summary>
	[JsonPropertyName("currencies")]
	public Dictionary<string, CurrencyInfo>? Currencies { get; set; }

	/// <summary>Demonyms by language code.</summary>
	[JsonPropertyName("demonyms")]
	public Dictionary<string, GenderedDemonym>? Demonyms { get; set; }

	// --- VOLÁNÍ (IDD + sjednocené calling codes) ---
	/// <summary>International direct dialing info.</summary>
	[JsonPropertyName("idd")]
	public IddInfo? Idd { get; set; }

	/// <summary>Calling codes if present in source.</summary>
	[JsonPropertyName("callingCodes")]
	public List<string>? CallingCodes { get; set; } // pokud bylo ve zdroji

	/// <summary>
	/// Captures any additional fields not explicitly mapped.
	/// </summary>
	[JsonExtensionData]
	public Dictionary<string, JsonElement>? Extra { get; set; }
}