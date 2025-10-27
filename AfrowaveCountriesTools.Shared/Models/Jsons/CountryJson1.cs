using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AfrowaveCountriesTools.Shared.Models.Jsons;

/// <summary>
/// Minimal country model with localized name, dial code, emoji flag, and country code.
/// </summary>
public sealed class CountryJson1
{
	/// <summary>
	/// Localized country name (common/official).
	/// </summary>
	[JsonPropertyName("name")]
	public LocalizedName? Name { get; set; }

	/// <summary>
	/// International dialing code, e.g. "+420".
	/// </summary>
	[JsonPropertyName("dial_code")]
	public string? DialCode { get; set; }

	/// <summary>
	/// Emoji flag for the country.
	/// </summary>
	[JsonPropertyName("emoji")]
	public string? Emoji { get; set; }

	/// <summary>
	/// Country alpha-2/alpha-3 code depending on source.
	/// </summary>
	[JsonPropertyName("code")]
	public string? Code { get; set; }
}