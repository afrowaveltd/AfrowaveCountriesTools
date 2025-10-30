using Microsoft.EntityFrameworkCore;
using AfrowaveCountriesTools.Shared.Models.Entities;

namespace AfrowaveCountriesTools.Shared.Data;

/// <summary>
/// Entity Framework Core database context for the Countries domain.
/// Defines entity sets and configures tables, keys, property constraints, and relationships.
/// </summary>
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
	/// <summary>
	/// Countries (root aggregate) table.
	/// </summary>
	public DbSet<Country> Countries => Set<Country>();
	/// <summary>
	/// Country names (one-to-one with Country).
	/// </summary>
	public DbSet<CountryNameEntity> CountryNames => Set<CountryNameEntity>();
	/// <summary>
	/// Flags (one-to-one with Country).
	/// </summary>
	public DbSet<FlagEntity> Flags => Set<FlagEntity>();
	/// <summary>
	/// International Direct Dialing info (one-to-one with Country).
	/// </summary>
	public DbSet<IddInfoEntity> Idds => Set<IddInfoEntity>();
	/// <summary>
	/// IDD suffixes (one-to-many from IddInfo).
	/// </summary>
	public DbSet<IddSuffix> IddSuffixes => Set<IddSuffix>();
	/// <summary>
	/// Top-level domains for countries.
	/// </summary>
	public DbSet<CountryTld> CountryTlds => Set<CountryTld>();
	/// <summary>
	/// Capital cities for countries.
	/// </summary>
	public DbSet<CountryCapital> CountryCapitals => Set<CountryCapital>();
	/// <summary>
	/// Alternative spellings for countries.
	/// </summary>
	public DbSet<CountryAltSpelling> CountryAltSpellings => Set<CountryAltSpelling>();
	/// <summary>
	/// Bordering country references.
	/// </summary>
	public DbSet<CountryBorder> CountryBorders => Set<CountryBorder>();
	/// <summary>
	/// Latitude/longitude coordinates for countries.
	/// </summary>
	public DbSet<CountryCoordinate> CountryCoordinates => Set<CountryCoordinate>();
	/// <summary>
	/// Calling codes for countries.
	/// </summary>
	public DbSet<CountryCallingCode> CountryCallingCodes => Set<CountryCallingCode>();
	/// <summary>
	/// Languages spoken in countries.
	/// </summary>
	public DbSet<CountryLanguage> CountryLanguages => Set<CountryLanguage>();
	/// <summary>
	/// Translations of country names.
	/// </summary>
	public DbSet<CountryTranslation> CountryTranslations => Set<CountryTranslation>();
	/// <summary>
	/// Gendered demonyms for countries.
	/// </summary>
	public DbSet<CountryDemonym> CountryDemonyms => Set<CountryDemonym>();
	/// <summary>
	/// Currencies reference table.
	/// </summary>
	public DbSet<Currency> Currencies => Set<Currency>();
	/// <summary>
	/// Many-to-many join between Country and Currency.
	/// </summary>
	public DbSet<CountryCurrency> CountryCurrencies => Set<CountryCurrency>();

	/// <summary>
	/// Configures entity mappings using the Fluent API.
	/// Sets table names, primary keys, property limits, and relationships including1:1,1:N, and M:N.
	/// </summary>
	/// <param name="modelBuilder">Model builder used to configure the model.</param>
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Country>(b =>
		{
			b.ToTable("Countries");
			b.HasKey(x => x.Id);
			b.Property(x => x.Cca2).HasMaxLength(2);
			b.Property(x => x.Cca3).HasMaxLength(3);
			b.Property(x => x.Cioc).HasMaxLength(3);
			b.Property(x => x.Ccn3).HasMaxLength(3);
			b.Property(x => x.Region).HasMaxLength(100);
			b.Property(x => x.Subregion).HasMaxLength(100);
			b.Property(x => x.DialCode).HasMaxLength(16);
			b.Property(x => x.FlagEmoji).HasMaxLength(8);

			//1:1 relations
			b.HasOne(x => x.Name)
				.WithOne(x => x.Country)
				.HasForeignKey<CountryNameEntity>(x => x.CountryId)
				.OnDelete(DeleteBehavior.Cascade);

			b.HasOne(x => x.Flags)
				.WithOne(x => x.Country)
				.HasForeignKey<FlagEntity>(x => x.CountryId)
				.OnDelete(DeleteBehavior.Cascade);

			b.HasOne(x => x.Idd)
				.WithOne(x => x.Country)
				.HasForeignKey<IddInfoEntity>(x => x.CountryId)
				.OnDelete(DeleteBehavior.Cascade);

			// Collections
			b.HasMany(x => x.Tlds).WithOne(x => x.Country).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Cascade);
			b.HasMany(x => x.Capitals).WithOne(x => x.Country).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Cascade);
			b.HasMany(x => x.AltSpellings).WithOne(x => x.Country).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Cascade);
			b.HasMany(x => x.Borders).WithOne(x => x.Country).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Cascade);
			b.HasMany(x => x.Coordinates).WithOne(x => x.Country).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Cascade);
			b.HasMany(x => x.CallingCodes).WithOne(x => x.Country).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Cascade);
			b.HasMany(x => x.Languages).WithOne(x => x.Country).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Cascade);
			b.HasMany(x => x.Translations).WithOne(x => x.Country).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Cascade);
			b.HasMany(x => x.Demonyms).WithOne(x => x.Country).HasForeignKey(x => x.CountryId).OnDelete(DeleteBehavior.Cascade);
		});

		modelBuilder.Entity<CountryNameEntity>(b =>
		{
			b.ToTable("CountryNames");
			b.HasKey(x => x.Id);
			b.Property(x => x.Common).HasMaxLength(200);
			b.Property(x => x.Official).HasMaxLength(300);
		});

		modelBuilder.Entity<FlagEntity>(b =>
		{
			b.ToTable("Flags");
			b.HasKey(x => x.Id);
			b.Property(x => x.Png).HasMaxLength(500);
			b.Property(x => x.Svg).HasMaxLength(500);
			b.Property(x => x.Alt).HasMaxLength(500);
		});

		modelBuilder.Entity<IddInfoEntity>(b =>
		{
			b.ToTable("IddInfos");
			b.HasKey(x => x.Id);
			b.Property(x => x.Root).HasMaxLength(8);
			b.HasMany<IddSuffix>()
				.WithOne(x => x.IddInfo)
				.HasForeignKey(x => x.IddInfoId)
				.OnDelete(DeleteBehavior.Cascade);
		});

		modelBuilder.Entity<IddSuffix>(b =>
		{
			b.ToTable("IddSuffixes");
			b.HasKey(x => x.Id);
			b.Property(x => x.Value).HasMaxLength(16);
		});

		modelBuilder.Entity<CountryTld>(b =>
		{
			b.ToTable("CountryTlds");
			b.HasKey(x => x.Id);
			b.Property(x => x.Value).HasMaxLength(50);
		});

		modelBuilder.Entity<CountryCapital>(b =>
		{
			b.ToTable("CountryCapitals");
			b.HasKey(x => x.Id);
			b.Property(x => x.Value).HasMaxLength(150);
		});

		modelBuilder.Entity<CountryAltSpelling>(b =>
		{
			b.ToTable("CountryAltSpellings");
			b.HasKey(x => x.Id);
			b.Property(x => x.Value).HasMaxLength(200);
		});

		modelBuilder.Entity<CountryBorder>(b =>
		{
			b.ToTable("CountryBorders");
			b.HasKey(x => x.Id);
			b.Property(x => x.Value).HasMaxLength(3);
		});

		modelBuilder.Entity<CountryCoordinate>(b =>
		{
			b.ToTable("CountryCoordinates");
			b.HasKey(x => x.Id);
		});

		modelBuilder.Entity<CountryCallingCode>(b =>
		{
			b.ToTable("CountryCallingCodes");
			b.HasKey(x => x.Id);
			b.Property(x => x.Value).HasMaxLength(16);
		});

		modelBuilder.Entity<CountryLanguage>(b =>
		{
			b.ToTable("CountryLanguages");
			b.HasKey(x => x.Id);
			b.Property(x => x.Code).HasMaxLength(10);
			b.Property(x => x.Name).HasMaxLength(100);
		});

		modelBuilder.Entity<CountryTranslation>(b =>
		{
			b.ToTable("CountryTranslations");
			b.HasKey(x => x.Id);
			b.Property(x => x.LangCode).HasMaxLength(10);
			b.Property(x => x.Official).HasMaxLength(300);
			b.Property(x => x.Common).HasMaxLength(200);
		});

		modelBuilder.Entity<CountryDemonym>(b =>
		{
			b.ToTable("CountryDemonyms");
			b.HasKey(x => x.Id);
			b.Property(x => x.LangCode).HasMaxLength(10);
			b.Property(x => x.Male).HasMaxLength(100);
			b.Property(x => x.Female).HasMaxLength(100);
		});

		modelBuilder.Entity<Currency>(b =>
		{
			b.ToTable("Currencies");
			b.HasKey(x => x.Id);
			b.HasIndex(x => x.Code).IsUnique();
			b.Property(x => x.Code).HasMaxLength(10);
			b.Property(x => x.Name).HasMaxLength(100);
			b.Property(x => x.Symbol).HasMaxLength(20);
		});

		modelBuilder.Entity<CountryCurrency>(b =>
		{
			b.ToTable("CountryCurrencies");
			b.HasKey(x => new { x.CountryId, x.CurrencyId });
			b.HasOne(x => x.Country)
				.WithMany(x => x.CountryCurrencies)
				.HasForeignKey(x => x.CountryId)
				.OnDelete(DeleteBehavior.Cascade);
			b.HasOne(x => x.Currency)
				.WithMany(x => x.CountryCurrencies)
				.HasForeignKey(x => x.CurrencyId)
				.OnDelete(DeleteBehavior.Cascade);
			b.Property(x => x.RawCode).HasMaxLength(10);
		});
	}
}