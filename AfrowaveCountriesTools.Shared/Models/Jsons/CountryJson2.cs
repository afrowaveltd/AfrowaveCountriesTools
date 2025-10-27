using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AfrowaveCountriesTools.Shared.Models.Jsons;

/// <summary>
/// Simplified country model with borders, code, flags, and name.
/// </summary>
public sealed class CountryJson2
{
	/// <summary>
	/// Neighboring country codes.
	/// </summary>
	[JsonPropertyName("borders")]
	public List<string>? Borders { get; set; }

	/// <summary>
	/// Country code.
	/// </summary>
	[JsonPropertyName("code")]
	public string? Code { get; set; }

	/// <summary>
	/// Flag resources.
	/// </summary>
	[JsonPropertyName("flags")]
	public Flag? Flags { get; set; }

	/// <summary>
	/// Country display name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }
}