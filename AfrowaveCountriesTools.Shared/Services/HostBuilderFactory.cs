using AfrowaveCountriesTools.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AfrowaveCountriesTools.Shared.Services;

public static class HostBuilderFactory
{
	public static IHost BuildHost(string[]? args = null)
	{
		var builder = Host.CreateDefaultBuilder(args ?? [])
			 .ConfigureAppConfiguration(cfg =>
			 {
				 cfg.SetBasePath(Directory.GetCurrentDirectory());
				 cfg.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
				 cfg.AddEnvironmentVariables();
			 })
			 .ConfigureServices((ctx, services) =>
			 {
				 var cs = ctx.Configuration.GetConnectionString("Default")
								?? "Data Source=./data/app.db";

				 // EF Core (SQLite) přes DbContextFactory
				 services.AddDbContextFactory<ApplicationDbContext>(opt =>
				 {
					 opt.UseSqlite(cs);
					 // opt.EnableSensitiveDataLogging(); // při ladění
				 });

				 // Tvoje služby / repozitáře
				 services.AddScoped<IUserRepository, UserRepository>();
			 });

		var host = builder.Build();

		// Volitelné: vytvoření složky a DB/migrací při startu
		EnsureDatabase(host);

		return host;
	}

	private static void EnsureDatabase(IHost host)
	{
		using var scope = host.Services.CreateScope();
		var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();
		var ensureMigrations = config.GetValue("EfCore:ApplyMigrationsAtStartup", true);

		Directory.CreateDirectory("./data");

		var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<ApplicationDbContext>>();
		using var db = factory.CreateDbContext();

		if(ensureMigrations)
		{
			db.Database.Migrate();     // použije migrace, pokud existují
		}
		else
		{
			db.Database.EnsureCreated(); // rychlé vytvoření bez migrací
		}
	}
}

// Jednoduchý repozitář