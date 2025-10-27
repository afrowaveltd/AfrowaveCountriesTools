using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AfrowaveCountriesTools.Shared.Models.Jsons;

/// <summary>
/// Two value representation of gendered demonyms (male/female).
/// </summary>
public sealed class GenderedDemonym
{
	/// <summary>
	/// Male demonym.
	/// </summary>
	[JsonPropertyName("m")]
	public string? Male { get; set; }

	/// <summary>
	/// Female demonym.
	/// </summary>
	[JsonPropertyName("f")]
	public string? Female { get; set; }
}