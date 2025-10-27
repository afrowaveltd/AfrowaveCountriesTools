using System.Collections.Generic;

namespace AfrowaveCountriesTools.Shared.Models.Entities;

/// <summary>
/// Represents a country with codes, status, geography, flags, and related collections.
/// </summary>
public class Country
{
	/// <summary>
	/// Primary key.
	/// </summary>
	public int Id { get; set; }

	// Codes
	/// <summary>ISO-3166 alpha-2 code.</summary>
	public string? Cca2 { get; set; }
	/// <summary>ISO-3166 numeric code.</summary>
	public string? Ccn3 { get; set; }
	/// <summary>ISO-3166 alpha-3 code.</summary>
	public string? Cca3 { get; set; }
	/// <summary>International Olympic Committee code.</summary>
	public string? Cioc { get; set; }

	// Status / Membership
	/// <summary>Indicates if the country is independent.</summary>
	public bool? Independent { get; set; }
	/// <summary>Status of the country/entity.</summary>
	public string? Status { get; set; }
	/// <summary>UN membership flag.</summary>
	public bool? UnMember { get; set; }

	// Phone / Flags
	/// <summary>International dialing code.</summary>
	public string? DialCode { get; set; }
	/// <summary>Emoji flag for the country.</summary>
	public string? FlagEmoji { get; set; }

	// Geography
	/// <summary>Geographical region.</summary>
	public string? Region { get; set; }
	/// <summary>Subregion.</summary>
	public string? Subregion { get; set; }
	/// <summary>Indicates if the country is landlocked.</summary>
	public bool? Landlocked { get; set; }
	/// <summary>Total area in square kilometers.</summary>
	public double? Area { get; set; }

	// One-to-ones
	/// <summary>Country name details.</summary>
	public CountryNameEntity? Name { get; set; }
	/// <summary>Flag asset references.</summary>
	public FlagEntity? Flags { get; set; }
	/// <summary>International direct dialing info.</summary>
	public IddInfoEntity? Idd { get; set; }

	// Collections
	/// <summary>Top-level domains.</summary>
	public ICollection<CountryTld> Tlds { get; set; } = [];
	/// <summary>Capital cities.</summary>
	public ICollection<CountryCapital> Capitals { get; set; } = [];
	/// <summary>Alternative spellings.</summary>
	public ICollection<CountryAltSpelling> AltSpellings { get; set; } = [];
	/// <summary>Bordering countries.</summary>
	public ICollection<CountryBorder> Borders { get; set; } = [];
	/// <summary>Latitude/longitude coordinates.</summary>
	public ICollection<CountryCoordinate> Coordinates { get; set; } = [];
	/// <summary>Calling codes.</summary>
	public ICollection<CountryCallingCode> CallingCodes { get; set; } = [];

	/// <summary>Languages spoken in the country.</summary>
	public ICollection<CountryLanguage> Languages { get; set; } = [];
	/// <summary>Translations of the country name.</summary>
	public ICollection<CountryTranslation> Translations { get; set; } = [];
	/// <summary>Demonyms by language code.</summary>
	public ICollection<CountryDemonym> Demonyms { get; set; } = [];

	/// <summary>Many-to-many relationship with currencies.</summary>
	public ICollection<CountryCurrency> CountryCurrencies { get; set; } = [];
}
