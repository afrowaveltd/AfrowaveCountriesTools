using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AfrowaveCountriesTools.Shared.Models.Jsons;

/// <summary>
/// Localized country name with official and common variants.
/// </summary>
public sealed class LocalizedName
{
	/// <summary>
	/// Official country name.
	/// </summary>
	[JsonPropertyName("official")]
	public string? Official { get; set; }

	/// <summary>
	/// Commonly used country name.
	/// </summary>
	[JsonPropertyName("common")]
	public string? Common { get; set; }
}