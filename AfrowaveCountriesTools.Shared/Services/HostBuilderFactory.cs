using AfrowaveCountriesTools.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AfrowaveCountriesTools.Shared.Services;

/// <summary>
/// Provides factory methods for creating and configuring application host instances using default settings and optional
/// custom service registrations.
/// </summary>
/// <remarks>This static class simplifies the setup of an application host by applying standard configuration
/// sources and registering core services, such as database contexts and repositories. It allows callers to inject
/// additional service registrations through a delegate, enabling customization for specific application needs. The host
/// is built with support for configuration from JSON files and environment variables, and ensures that the database is
/// created or migrated at startup. This class is intended for use in applications that require a consistent and
/// extensible host initialization process.</remarks>
public static class HostBuilderFactory
{
   /// <summary>
   /// Builds and configures a generic host for the application, including default configuration, services, and optional
   /// custom service registrations.
   /// </summary>
   /// <remarks>The host is configured with default settings, including reading configuration from
   /// 'appsettings.json' and environment variables. Entity Framework Core is set up with a SQLite database connection.
   /// The method ensures the database and its directory exist before returning the host. Custom services can be
   /// registered via the <paramref name="configureServices"/> delegate.</remarks>
   /// <param name="args">An array of command-line arguments to initialize the host configuration. If null or empty, default configuration
   /// is used.</param>
   /// <param name="configureServices">An optional delegate to register additional services or modify the service collection during host building.
   /// Receives the host builder context and the service collection.</param>
   /// <returns>An initialized <see cref="IHost"/> instance configured with application settings, services, and any additional
   /// customizations provided.</returns>
   public static IHost BuildHost(string[]? args = null, Action<HostBuilderContext, IServiceCollection>? configureServices = null)
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

             // Allow startup projects to register their own services (e.g., ViewModels)
             configureServices?.Invoke(ctx, services);
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
      var ensureMigrations = config.GetSection("EfCore").GetValue<bool>("ApplyMigrationsAtStartup", true);
      if(!Directory.Exists("./data"))
         Directory.CreateDirectory("./data");

      var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<ApplicationDbContext>>();
      using var db = factory.CreateDbContext();

      if(ensureMigrations)
      {
         db.Database.Migrate(); // použije migrace, pokud existují
      }
      else
      {
         db.Database.EnsureCreated(); // rychlé vytvoření bez migrací
      }
   }
}